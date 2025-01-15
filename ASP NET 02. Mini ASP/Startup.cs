using ASP_NET_02._Mini_ASP.Interfaces;
using ASP_NET_02._Mini_ASP.Midlwares;

namespace ASP_NET_02._Mini_ASP;

internal class Startup : IStartup
{
    public void Configure(MidlewareBuilder builder)
    {
        builder.Use<LoggerMidleware>();
        builder.Use<StaticFilesMidleware>();
    }
}
