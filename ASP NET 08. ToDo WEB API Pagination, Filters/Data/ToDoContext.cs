using ASP_NET_08._ToDo_WEB_API_Pagination__Filters.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_08._ToDo_WEB_API_Pagination__Filters.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) : base(options)
    {}
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
}
