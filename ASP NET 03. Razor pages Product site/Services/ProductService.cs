using ASP_NET_03._Razor_pages_Product_site.Data;
using ASP_NET_03._Razor_pages_Product_site.Models;
using Bogus;

namespace ASP_NET_03._Razor_pages_Product_site.Services;

public class ProductService
{
    private readonly IProductRepsitory _productRepsitory;

    public ProductService(IProductRepsitory productRepsitory)
    {
        _productRepsitory = productRepsitory;
    }

    public Task<IEnumerable<Product>> GetProductsAsync()
    {
        return _productRepsitory.GetProductsAsync();
    }

    public Task<Product> GetProductByIdAsync(int id)
    {
        return _productRepsitory.GetProductByIdAsync(id);
    }

    public Product AddProduct(Product product)
    {
        var faker = new Faker<Product>().RuleFor(p => p.Id, f => f.Random.Int(1));
        product.Id = faker.Generate().Id;
        if(product.Count > 0)
        {
            product.Available = true;
        }
        _productRepsitory.AddProduct(product);
        return product;
    }

}
