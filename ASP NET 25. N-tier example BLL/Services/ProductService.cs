using ASP_NET_25._N_tier_example_DAL.Repositories;
using ASP_NET_25._N_tier_example_Models.Models;

namespace ASP_NET_25._N_tier_example_BLL.Services;

public class ProductService
{
    private readonly ProductRepository _repository;

    public ProductService(ProductRepository repository)
    {
        _repository = repository;
    }

    public List<Product> GetAllProducts()
    {
        return _repository.GetProducts();
    }
}
