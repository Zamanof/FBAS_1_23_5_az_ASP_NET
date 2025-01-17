using ASP_NET_03._Dependency_injection___services.Models;
namespace ASP_NET_03._Dependency_injection___services.Data;

public interface IProductRepository
{
    public Product AddProduct(Product product);
    public IEnumerable<Product> GetProducts();
}
