using Microsoft.AspNetCore.Identity;

namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.Models;
/// <summary>
/// 
/// </summary>
public class AppUser : IdentityUser
{
    /// <summary>
    /// 
    /// </summary>
    public string? RefreshToken {  get; set; }

    public virtual ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
}
