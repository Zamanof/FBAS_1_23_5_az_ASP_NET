using ASP_NET_25._N_tier_example_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_25._N_tier_example_Data.Data;

public class ApllicationDbContext : DbContext
{
    public ApllicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Product> Products { get; set; }    

}
