using ASO_NET_04._Products_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASO_NET_04._Products_MVC.Data;

public class ProductsMVCContext : DbContext
{
    public ProductsMVCContext(DbContextOptions options) 
        : base(options)
    {}

    public DbSet<Product> Products => Set<Product>();
}
