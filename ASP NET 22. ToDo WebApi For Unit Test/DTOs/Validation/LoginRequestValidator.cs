using ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs.Auth;
using FluentValidation;

namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs.Validation;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        //RuleFor(x => x.Password).MinimumLength(8).Must(SaharedValidator.BeValidPassword).NotEmpty();
        RuleFor(x => x.Password).Password().NotEmpty();
    }
}
