using ASP_NET_02._Mini_ASP.Interfaces;

namespace ASP_NET_02._Mini_ASP;

internal class MidlewareBuilder
{
    private Stack<Type> midlewares = new();
    public void Use<T> () where T: IMidleware
    {
        midlewares.Push(typeof(T));
    }
    public HttpHandler Build()
    {
        HttpHandler handler = context=> context.Response.Close();
        while (midlewares.Count != 0) 
        {
            var midleware = midlewares.Pop();
            IMidleware? midleWare = Activator.CreateInstance(midleware) as IMidleware;
            midleWare.Next = handler;
            handler = midleWare.Handle;
        }
        return handler;
    }
}
