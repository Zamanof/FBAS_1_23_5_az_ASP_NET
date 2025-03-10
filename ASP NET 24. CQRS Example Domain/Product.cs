namespace ASP_NET_24._CQRS_Example_Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty!!!");
        if (price <= 0)
            throw new ArgumentException("Еhe price must be positive!!!");
        Name = name;
        Price = price;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Еhe price must be positive!!!");
        Price = newPrice;
    }
}
