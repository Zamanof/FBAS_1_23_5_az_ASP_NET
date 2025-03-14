﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_NET_05._Filters.Filters;

public class ApiKeyQueryAuthorization : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var isAuthorized = context
                       .HttpContext
                       .Request
                       .Query
                       .Any(q => q.Key == "apiKey" && q.Value == "Pass12345");
        if (!isAuthorized)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
