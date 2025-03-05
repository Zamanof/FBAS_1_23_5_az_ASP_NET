using FluentValidation;
using ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs.Auth;
using System.Text.RegularExpressions;
namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs.Validation;


public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        //RuleFor(x => x.Password).MinimumLength(8).Must(BeValidPassword).NotEmpty();
        //RuleFor(x => x.Password).MinimumLength(8).Must(SaharedValidator.BeValidPassword).NotEmpty();
        RuleFor(x=>x.Password).MinimumLength(8).Password(mustContainsDigit:false).NotEmpty();
    }

    //private bool BeValidPassword(string password)
    //{
    //    return new Regex(@"\d").IsMatch(password) 
    //        && new Regex(@"[a-z]").IsMatch(password)
    //        && new Regex(@"[A-Z]").IsMatch(password);
    //}
}
