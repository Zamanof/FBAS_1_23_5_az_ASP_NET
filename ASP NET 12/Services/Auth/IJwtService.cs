using System.Security.Claims;

namespace ASP_NET_12.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
