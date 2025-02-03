using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) : base(options)
    {}
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
}
