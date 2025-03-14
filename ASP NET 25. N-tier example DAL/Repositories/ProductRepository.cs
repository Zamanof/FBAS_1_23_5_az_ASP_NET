using ASP_NET_25._N_tier_example_Data.Data;
using ASP_NET_25._N_tier_example_Models.Models;

namespace ASP_NET_25._N_tier_example_DAL.Repositories;

public class ProductRepository
{
    private readonly ApllicationDbContext _context;

    public ProductRepository(ApllicationDbContext context)
    {
        _context = context;
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }
}
