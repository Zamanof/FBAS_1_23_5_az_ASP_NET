using ASP_NET_12;
using ASP_NET_12.Data;
using ASP_NET_12.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x=>x.EnablePersistAuthorization());
}

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
