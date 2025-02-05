using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Data;
/// <summary>
/// 
/// </summary>
public class ToDoContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public ToDoContext(DbContextOptions options) : base(options)
    {}
    /// <summary>
    /// 
    /// </summary>
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
}
