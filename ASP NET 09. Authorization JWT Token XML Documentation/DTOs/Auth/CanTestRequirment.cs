using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs.Auth;

public class CanTestRequirment : IAuthorizationRequirement, IAuthorizationHandler
{
    public Task HandleAsync(AuthorizationHandlerContext context)
    {
        var claim = context.User.Claims.FirstOrDefault(c=>c.Type == "permissions");
        if (claim is not null)
        {
            var permissions = JsonSerializer.Deserialize<string[]>(claim.Value);
            if (permissions.Contains("CanTest"))
            {
                context.Succeed(this);
            }
            else
            {
                context.Fail();
            }
        }
        else
        {
            context.Fail();
        }
        return Task.CompletedTask;

    }
}
