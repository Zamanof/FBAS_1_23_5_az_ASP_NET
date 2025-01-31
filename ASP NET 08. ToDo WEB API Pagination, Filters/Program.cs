using ASP_NET_08._ToDo_WEB_API_Pagination__Filters.Data;
using ASP_NET_08._ToDo_WEB_API_Pagination__Filters.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
