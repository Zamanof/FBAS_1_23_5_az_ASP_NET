﻿namespace ASP_NET_03._Dependency_injection___services.Models;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
}
