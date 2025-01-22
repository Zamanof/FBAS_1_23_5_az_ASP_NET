namespace ASP_NET_05._HTML_Helpers.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return $"{Id}. {Login}";
    }
}
