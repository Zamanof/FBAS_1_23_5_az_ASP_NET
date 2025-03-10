using MediatR;

namespace ASP_NET_24._CQRS_Example_Application;

public record CreateProductCommand(string Name, decimal Price): IRequest<int>;
public record UpdateProductPriceCommand(int Id, decimal newPrice): IRequest<bool>;
public record DeleteProductCommand(int Id): IRequest<bool>;
