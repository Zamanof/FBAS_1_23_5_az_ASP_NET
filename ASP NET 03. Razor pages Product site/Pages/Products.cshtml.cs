using ASP_NET_03._Razor_pages_Product_site.Models;
using ASP_NET_03._Razor_pages_Product_site.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_NET_03._Razor_pages_Product_site.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductService _productService;
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

        public ProductsModel(ProductService productService)
        {
            _productService = productService;
        }

        public async void OnGet()
        {
            Products = await _productService.GetProductsAsync();
        }
    }
}
