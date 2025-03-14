namespace ASP_NET_25._N_tier_example_API;

using ASP_NET_25._N_tier_example_BLL.Services;
using ASP_NET_25._N_tier_example_DAL.Repositories;
using ASP_NET_25._N_tier_example_Data.Data;
using Microsoft.EntityFrameworkCore;

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
        builder.Services.AddDbContext<ApllicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("n-tier"));
        });
        builder.Services.AddScoped<ProductRepository>();
        builder.Services.AddScoped<ProductService>();



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
