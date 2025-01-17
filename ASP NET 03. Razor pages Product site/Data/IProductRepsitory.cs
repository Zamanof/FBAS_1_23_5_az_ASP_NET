using ASP_NET_03._Razor_pages_Product_site.Models;

namespace ASP_NET_03._Razor_pages_Product_site.Data;

public interface IProductRepsitory
{
    public Task<IEnumerable<Product>> GetProductsAsync();
    public Task<Product> GetProductByIdAsync(int id);
    public Product AddProduct(Product product);
    
}
