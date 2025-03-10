using ASP_NET_24._CQRS_Example_Domain;

namespace ASP_NET_24._CQRS_Example_Infrastructure;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<int> AddAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);
}
