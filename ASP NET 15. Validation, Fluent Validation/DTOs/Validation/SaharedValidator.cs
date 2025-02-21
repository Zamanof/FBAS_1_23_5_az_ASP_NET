using System.Text.RegularExpressions;

namespace ASP_NET_15._Validation__Fluent_Validation.DTOs.Validation;

public static class SaharedValidator
{
    public static bool BeValidPassword(string password)
    {
        return new Regex(@"\d").IsMatch(password)
            && new Regex(@"[a-z]").IsMatch(password)
            && new Regex(@"[A-Z]").IsMatch(password);
    }
}
