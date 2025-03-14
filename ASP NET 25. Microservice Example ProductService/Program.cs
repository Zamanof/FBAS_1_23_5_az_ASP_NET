
using ASP_NET_25._Microservice_Example_ProductService.Data;
using ASP_NET_25._Microservice_Example_ProductService.Repositories;
using ASP_NET_25._Microservice_Example_ProductService.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_25._Microservice_Example_ProductService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("microservice"));
            });
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddMassTransit(x =>
          x.UsingRabbitMq((context, config) =>
          {
              config.Host("rabbitmq://localhost");
          })
              );

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
        }
    }
}
