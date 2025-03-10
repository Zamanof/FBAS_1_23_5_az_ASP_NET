using ASP_NET_24._CQRS_Example_Domain;
using ASP_NET_24._CQRS_Example_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_24._CQRS_Example_Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> AddAsync(Product product)
    {
        await _appDbContext.Products.AddAsync(product);
        await _appDbContext.SaveChangesAsync();
        return product.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _appDbContext.Products.FindAsync(id);
        if (product is null) return false;
        _appDbContext.Products.Remove(product);
        return await _appDbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<Product>> GetAllAsync()
        => await _appDbContext.Products.ToListAsync();

    public async Task<Product> GetByIdAsync(int id)
        => (await _appDbContext.Products.FindAsync(id))!;

    public async Task<bool> UpdateAsync(Product product)
    {
        _appDbContext.Products.Update(product);
        return await _appDbContext.SaveChangesAsync() > 0;
    }
}
