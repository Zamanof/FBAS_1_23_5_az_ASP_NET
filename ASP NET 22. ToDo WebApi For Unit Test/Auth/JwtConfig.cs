namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.Auth;

public class JwtConfig
{
    public string Secret {  get; set; } = string.Empty;
    public string Issuer {  get; set; } = string.Empty;
    public string Audience {  get; set; } = string.Empty;
    public int Expiration {  get; set; }
}
