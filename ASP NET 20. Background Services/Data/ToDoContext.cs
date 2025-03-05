using ASP_NET_20._Background_Services.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_20._Background_Services.Data;
/// <summary>
/// 
/// </summary>
public class ToDoContext : IdentityDbContext
{     
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>  
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {}
    /// <summary>
    /// 
    /// </summary>
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
    /// <summary>
    /// 
    /// </summary>
    public DbSet<AppUser> AppUsers => Set<AppUser>();
    /// <summary>
    /// 
    /// </summary>
    public DbSet<Transaction> Transactions => Set<Transaction>();
}
