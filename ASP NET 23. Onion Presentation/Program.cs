using ASP_NET_23._Onion_Application.Services;
using ASP_NET_23._Onion_Domain.Interfaces;
using ASP_NET_23._Onion_Domain.Services;
using ASP_NET_23._Onion_Infrastructure.Data;
using ASP_NET_23._Onion_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Onion;Trusted_Connection=True;Integrated Security=SSPI;"));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserAppService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
