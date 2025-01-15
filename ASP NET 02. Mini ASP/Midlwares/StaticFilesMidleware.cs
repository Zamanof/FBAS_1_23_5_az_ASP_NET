using System.Net;
using ASP_NET_02._Mini_ASP.Interfaces;

namespace ASP_NET_02._Mini_ASP.Midlwares;

internal class StaticFilesMidleware : IMidleware
{
    public HttpHandler Next { get; set; }

    public void Handle(HttpListenerContext context)
    {
        if (Path.HasExtension(context.Request.RawUrl))
        {
            try
            {
                var fileName = context.Request.RawUrl.Substring(1);
                var path = $@"../../../wwwroot\{fileName}";
                var bytes = File.ReadAllBytes(path);
                if (Path.GetExtension(path) == "html")
                {
                    context.Response.AddHeader("Content-Type", "text/html");
                }
                else if (Path.GetExtension(path) == "png")
                {
                    context.Response.AddHeader("Content-Type", "image/png");
                }
                context.Response.OutputStream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 404;
                context.Response.StatusDescription = "File Not Found";
            }
        }
        else
        {
            Next.Invoke(context);
        }
        context.Response.Close();
    }
}
