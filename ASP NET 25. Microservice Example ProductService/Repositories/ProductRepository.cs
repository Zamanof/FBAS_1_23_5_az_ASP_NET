using ASP_NET_25._Microservice_Example_ProductService.Data;
using ASP_NET_25._Microservice_Example_ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_25._Microservice_Example_ProductService.Repositories;

public class ProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
}
