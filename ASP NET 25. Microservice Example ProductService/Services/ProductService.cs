using ASP_NET_25._Microservice_Example_ProductService.Models;
using ASP_NET_25._Microservice_Example_ProductService.Repositories;

namespace ASP_NET_25._Microservice_Example_ProductService.Services;

public class ProductService
{
    private readonly ProductRepository _repository;

    public ProductService(ProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _repository.GetAllProductsAsync();
    }
}
