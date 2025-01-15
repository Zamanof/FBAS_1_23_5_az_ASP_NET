using System.Net;
using ASP_NET_02._Mini_ASP.Interfaces;

namespace ASP_NET_02._Mini_ASP;

internal class WebHost
{
    private int _port;
    private HttpHandler _handler;
    private HttpListener _listener;
    private MidlewareBuilder _builder = new();

    public WebHost(int port)
    {
        _port = port;
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://localhost:{_port}/");
    }

    public void Run()
    {
        _listener.Start();
        Console.WriteLine($"Server started at {_port}");
        while ( true )
        {
            HttpListenerContext context = _listener.GetContext();
            Task.Run(() => HandlerRequest(context));
        }
    }
    public void UseStartup<T>() where T: IStartup, new()
    {
        IStartup startup = new T();
        startup.Configure(_builder);
        _handler = _builder.Build();
    }
    private void HandlerRequest(HttpListenerContext context)
    {
        _handler.Invoke(context);
    }
}
