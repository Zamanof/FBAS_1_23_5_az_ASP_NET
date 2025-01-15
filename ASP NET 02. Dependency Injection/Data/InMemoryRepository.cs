using ASP_NET_02._Dependency_Injection.Models;

namespace ASP_NET_02._Dependency_Injection.Data;

public class InMemoryRepository : IProductRepository
{
    private readonly IDictionary<Guid, Product> _products = new Dictionary<Guid, Product>();

    public InMemoryRepository()
    {
        AddProduct(new Product
        {
            Name = "Azerbaycan choreyi",
            Description = "Chorek bol olarsa basilmaz veten."
        });
        AddProduct(new Product
        {
            Name = "Naz Lifan",
            Description = "Hami yerli mal alsin xeyir vetene qalsin."
        });
        AddProduct(new Product
        {
            Name = "Samsung S24 Ultra",
            Description = "Ayi cheke bilen telefon. IPhone-un gozu yashli."
        });
        AddProduct(new Product
        {
            Name = "STEP IT Academy Software Developer course",
            Description = "Gel deee."
        });
    }

    public Product AddProduct(Product product)
    {
        product.Id = Guid.NewGuid();
        _products.Add(product.Id, product);
        return product;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products.Values;
    }
}
