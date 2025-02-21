using System.Security.Claims;

namespace ASP_NET_15._Validation__Fluent_Validation.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string Id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
