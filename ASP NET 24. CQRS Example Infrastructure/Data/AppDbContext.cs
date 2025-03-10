using ASP_NET_24._CQRS_Example_Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_24._CQRS_Example_Infrastructure.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Product> Products { get; set; }

}
