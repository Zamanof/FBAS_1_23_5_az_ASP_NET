using ASP_NET_23._Onion_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_23._Onion_Infrastructure.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }

 

}
