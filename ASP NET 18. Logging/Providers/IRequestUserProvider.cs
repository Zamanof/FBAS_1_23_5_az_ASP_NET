namespace ASP_NET_18._Logging.Providers;

public interface IRequestUserProvider
{
    UserInfo? GetUserInfo();
}
