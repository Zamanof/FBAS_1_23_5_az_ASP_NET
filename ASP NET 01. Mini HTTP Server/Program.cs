using System.Net;
new WebHost(27001).Run();

class WebHost
{
    int port;
    string pathBase = @"..\..\..\";
    HttpListener httpListener;

    public WebHost(int port)
    {
        this.port = port;
    }
    public void Run()
    {
        httpListener = new HttpListener();
        httpListener.Prefixes.Add($@"http://localhost:{port}/");
        httpListener.Start();
        Console.WriteLine($"Http server started on {port}");

        while ( true )
        {
            var context = httpListener.GetContext();
            Task.Run(() => {
                HandleRequest(context);
            
            });
        }
    }

    private void HandleRequest(HttpListenerContext context)
    {
        var url = context.Request.RawUrl;
        var path = $@"{pathBase}{url.Split("/").Last()}";
        //Console.WriteLine(path);
        var response = context.Response;
        StreamWriter streamWriter = new(response.OutputStream);
        try
        {
            var src = File.ReadAllText(path);
            streamWriter.WriteLine(src);
        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex.Message);
            var src = File.ReadAllText(@$"{pathBase}404.html");

            //Console.WriteLine(src);
            streamWriter.WriteLine(src);
        }
        finally { streamWriter.Close(); }
    }
}