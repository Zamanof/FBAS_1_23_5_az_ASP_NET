using System.Net;
using ASP_NET_02._Mini_ASP.Interfaces;

namespace ASP_NET_02._Mini_ASP.Midlwares;

internal class LoggerMidleware : IMidleware
{
    public HttpHandler Next { get; set; }

    public void Handle(HttpListenerContext context)
    {
        Console.WriteLine($@"{context.Request.HttpMethod}
{context.Request.RawUrl}
{context.Request.RemoteEndPoint}");
        Next.Invoke(context);
    }
}
