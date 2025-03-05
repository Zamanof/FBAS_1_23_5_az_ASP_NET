using System.Security.Claims;

namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string Id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
