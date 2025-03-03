namespace ASP_NET_20._Background_Services.Providers;
/// <summary>
/// 
/// </summary>
public class UserInfo
{
    public string Id {  get;}
    public string UserName {  get;}

    public UserInfo(string id, string userName)
    {
        Id = id;
        UserName = userName;
    }
}
