using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult<AuthTokenDto>> Login(
        [FromBody] LoginRequest request
        )
    {
        if (request is not { Login:"admin", Password:"admin"})
        {
            return Unauthorized();
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Supper pupper mupper hard secure Key"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "https://localhost:5143",
            audience: "https://localhost:5143",
            expires: DateTime.UtcNow.AddMinutes(3),
            signingCredentials: signingCredentials
            );
        var tokenValue = new JwtSecurityTokenHandler()
                                .WriteToken(token);
        return new AuthTokenDto { Token= tokenValue};
    }
}
