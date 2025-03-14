using ASP_NET_25._Microservice_Example_ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_25._Microservice_Example_ProductService.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
    }
}
