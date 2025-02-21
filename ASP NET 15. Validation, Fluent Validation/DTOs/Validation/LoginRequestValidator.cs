using ASP_NET_15._Validation__Fluent_Validation.DTOs.Auth;
using FluentValidation;

namespace ASP_NET_15._Validation__Fluent_Validation.DTOs.Validation;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        //RuleFor(x => x.Password).MinimumLength(8).Must(SaharedValidator.BeValidPassword).NotEmpty();
        RuleFor(x => x.Password).Password().NotEmpty();
    }
}
