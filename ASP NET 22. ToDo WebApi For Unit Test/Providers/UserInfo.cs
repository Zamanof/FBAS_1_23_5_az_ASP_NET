namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.Providers;
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
