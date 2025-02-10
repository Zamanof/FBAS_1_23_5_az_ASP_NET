using Microsoft.AspNetCore.Identity;

namespace ASP_NET_12.Models;
/// <summary>
/// 
/// </summary>
public class AppUser : IdentityUser
{
    /// <summary>
    /// 
    /// </summary>
    public string? RefreshToken {  get; set; }
}
