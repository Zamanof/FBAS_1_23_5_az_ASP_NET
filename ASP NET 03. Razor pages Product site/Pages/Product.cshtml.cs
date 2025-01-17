using ASP_NET_03._Razor_pages_Product_site.Models;
using ASP_NET_03._Razor_pages_Product_site.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_NET_03._Razor_pages_Product_site.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ProductService _productService;
        public Product Product { get; set; }

        public ProductModel(ProductService productService)
        {
            _productService = productService;
        }

        public async void OnGetAsync(int id)
        {
            Product = await _productService.GetProductByIdAsync(id);
        }
    }
}
