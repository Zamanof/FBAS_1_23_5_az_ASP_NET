namespace ASP_NET_15._Validation__Fluent_Validation.Auth;

public class JwtConfig
{
    public string Secret {  get; set; } = string.Empty;
    public string Issuer {  get; set; } = string.Empty;
    public string Audience {  get; set; } = string.Empty;
    public int Expiration {  get; set; }
}
