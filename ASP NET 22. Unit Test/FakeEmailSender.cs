using ASP_NET_22._ToDo_WebApi_For_Unit_Test.Services;

namespace ASP_NET_22._Unit_Test;

class FakeEmailSender : IEmailSender
{
    public Task SendEmail(string to, string text, string title)
    {
        return Task.CompletedTask;
    }
}
