using ASP_NET_07._WEB_API___DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_07._WEB_API___DTO.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) : base(options)
    {}
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
}
