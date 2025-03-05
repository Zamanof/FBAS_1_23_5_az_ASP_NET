using System.ComponentModel.DataAnnotations;
namespace ASP_NET_20._Background_Services.DTOs.Auth;

public class RegisterRequest
{
    //[EmailAddress]
    //[Required]
    public string Email {  get; set; }

    //[Required]
    //[MinLength(8)]
    public string Password {  get; set; }

    //[Required]
    //[UserName]
    //public string UserName {  get; set; }
}

//public class UserNameAttribute: ValidationAttribute
//{
//    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//    {
//        if (value is not string userName)
//        {
//            return new ValidationResult("UserName is not a string");
//        }

//        if(userName.Length < 2)
//        {
//            return new ValidationResult("UserName is short");
//        }
//        return ValidationResult.Success;
//    }

//}
