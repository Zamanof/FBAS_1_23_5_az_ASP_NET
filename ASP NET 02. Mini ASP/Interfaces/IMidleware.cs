﻿using System.Net;

namespace ASP_NET_02._Mini_ASP.Interfaces;
public delegate void HttpHandler(HttpListenerContext context);
internal interface IMidleware
{
    public HttpHandler Next { get; set; }
    public void Handle(HttpListenerContext context);
}
