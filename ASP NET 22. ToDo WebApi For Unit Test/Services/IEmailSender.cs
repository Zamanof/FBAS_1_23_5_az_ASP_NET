namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.Services;

public interface IEmailSender
{
    Task SendEmail(string to, string text, string title);
}
