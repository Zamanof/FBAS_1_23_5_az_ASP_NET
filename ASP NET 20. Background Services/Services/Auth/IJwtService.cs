using System.Security.Claims;

namespace ASP_NET_20._Background_Services.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string Id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
