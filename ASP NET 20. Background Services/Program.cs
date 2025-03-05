using ASP_NET_20._Background_Services;
using ASP_NET_20._Background_Services.Data;
using ASP_NET_20._Background_Services.DTOs.Auth;
using ASP_NET_20._Background_Services.DTOs.Validation;
using ASP_NET_20._Background_Services.HostedServices;
using ASP_NET_20._Background_Services.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Quartz;
using Quartz.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TODO_DBContext");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AuthenticationAndAuthorization(builder.Configuration);

builder.Services.AddSwagger();

//builder.Services.AddLogging(s =>
//{
//    s.SetMinimumLevel(LogLevel.Error);
//    s.AddJsonConsole();
//});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .Enrich.WithProcessName()
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}" +
    "ThreadId: {ThreadId}{NewLine}" +
    "ThreadName: {ThreadName}{NewLine}" +
    "ProcessName: {ProcessName}{NewLine}{Exception}")
    .WriteTo.MSSqlServer(restrictedToMinimumLevel: LogEventLevel.Error,
        connectionString: connectionString,
        sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents" })
    //.WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();


builder.Services.AddScoped<IToDoService, ToDoService>();
//builder.Services.AddSingleton<MessageQueue>();
//builder.Services.AddHostedService<TransactionProcessorJob>();
//builder.Services.AddHostedService<DatabaseClearJob>();

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    //q.ScheduleJob<DatabaseClearCronJob>(trigger => trigger.WithCronSchedule("0 * * ? * * *"));

    var jobKey = new JobKey("DatabaseClearCronJob");
    q.AddJob<DatabaseClearCronJob>(o => o.WithIdentity(jobKey));

    q.AddTrigger(o => 
    o.ForJob(jobKey)
    .WithIdentity("DatabaseClearCronJob-trigger")
    .WithCronSchedule("0 * * ? * * *")
    );
}
);
builder.Services.AddQuartzServer(options => options.WaitForJobsToComplete = true);


builder.Services.AddDbContext<ToDoContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    });

builder.Services.AddCors(
    options =>
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder.AllowAnyMethod()
                   .AllowAnyHeader()
                   .WithOrigins("http://localhost:5174", "http://localhost:5173")
                   .AllowCredentials();

        }
    )
);

builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
//builder.Services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => x.EnablePersistAuthorization());
}

//app.UseSerilogRequestLogging();

//app.UseResponseCaching();

app.UseCors("CORSPolicy");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
