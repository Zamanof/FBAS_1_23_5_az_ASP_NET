using ASP_NET_03._Dependency_injection___services.Data;
using ASP_NET_03._Dependency_injection___services.Models;
using ASP_NET_03._Dependency_injection___services.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ASP_NET_03._Dependency_injection___services.Pages;

public class IndexModel : PageModel
{
    private readonly ProductService _service;

    public IndexModel(ProductService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        var products = _service.GetProducts();
        ViewData["Products"] = products;
    }
    
    public void OnPost(Product product)
    {
        _service.AddProduct(product);
        //ViewData["Products"] = _service.GetProducts();
        OnGet();
    }
}


