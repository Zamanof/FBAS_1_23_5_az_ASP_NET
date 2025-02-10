using System.ComponentModel.DataAnnotations;

namespace ASP_NET_12.DTOs.Auth;

public class RegisterRequest
{
    [EmailAddress]
    [Required]
    public string Email {  get; set; }

    [Required]
    [MinLength(8)]
    public string Password {  get; set; }


}
