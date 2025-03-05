using ASP_NET_15._Validation__Fluent_Validation;
using ASP_NET_15._Validation__Fluent_Validation.Data;
using ASP_NET_15._Validation__Fluent_Validation.DTOs.Validation;
using ASP_NET_15._Validation__Fluent_Validation.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AuthenticationAndAuthorization(builder.Configuration);

builder.Services.AddSwagger();


builder.Services.AddScoped<IToDoService, ToDoService>();


builder.Services.AddDbContext<ToDoContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("TODO_DBContext"));
    });

builder.Services.AddCors(
    options => 
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder.AllowAnyMethod()
                   .AllowAnyHeader()
                   .WithOrigins("http://localhost:5174")
                   .AllowCredentials();

        }
    )
    );

builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
//builder.Services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => x.EnablePersistAuthorization());
}

app.UseCors("CORSPolicy");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
