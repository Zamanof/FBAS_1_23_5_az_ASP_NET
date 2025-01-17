using ASP_NET_03._Razor_pages_Product_site.Models;
using ASP_NET_03._Razor_pages_Product_site.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_NET_03._Razor_pages_Product_site.Pages
{
    public class IndexModel : PageModel
    {
       private readonly ProductService _productService;

        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }

        public void OnPost(Product product)
        {
            _productService.AddProduct(product);
        }
    }
}
