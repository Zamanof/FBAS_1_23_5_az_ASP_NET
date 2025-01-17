namespace ASP_NET_03._Razor_pages_Product_site.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public uint Count { get; set; }
    public decimal Price {  get; set; }
    public bool Available {  get; set; }
}
