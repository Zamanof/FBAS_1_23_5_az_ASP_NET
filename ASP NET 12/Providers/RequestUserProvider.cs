namespace ASP_NET_12.Providers;

public class RequestUserProvider : IRequestUserProvider
{
    private readonly HttpContext _httpContext;

    public RequestUserProvider(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext.HttpContext!;
    }

    public UserInfo? GetUserInfo()
    {
        if (!_httpContext.User.Claims.Any()) return null;
        var userId = _httpContext.User.Claims.First(c=>c.Type == "userId").Value;
        var userName = _httpContext.User.Identity!.Name;
        return new UserInfo(userId, userName!);

    }
}
