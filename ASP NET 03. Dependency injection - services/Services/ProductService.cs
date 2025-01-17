using ASP_NET_03._Dependency_injection___services.Data;
using ASP_NET_03._Dependency_injection___services.Models;

namespace ASP_NET_03._Dependency_injection___services.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public Product AddProduct(Product product)
    {
       return _repository.AddProduct(product);
    }

    public IEnumerable<Product> GetProducts() 
    {
        return _repository.GetProducts();
    }
}
