using FluentValidation;
using System.Text.RegularExpressions;

namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs.Validation;

public static class ValidationRulesExtensions
{
    public static IRuleBuilderOptions<T, string> Password<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        bool mustContainsLowerCase = true,
        bool mustContainsUpperCase = true,
        bool mustContainsDigit = true
        )
    {
        IRuleBuilderOptions<T, string> options = default!;
        if ( mustContainsLowerCase )
        {
            options = ruleBuilder.Must(p=> new Regex(@"[a-z]").IsMatch(p));
        }
        if (mustContainsUpperCase)
        {
            options = ruleBuilder.Must(p => new Regex(@"[A-Z]").IsMatch(p));
        }
        if (mustContainsDigit)
        {
            options = ruleBuilder.Must(p => new Regex(@"\d").IsMatch(p));
        }
        return options;
    }
}
