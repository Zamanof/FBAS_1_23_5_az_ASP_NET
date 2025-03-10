using ASP_NET_24._CQRS_Example_Domain;
using MediatR;

namespace ASP_NET_24._CQRS_Example_Application;

public record GetProductByIdQuery(int Id): IRequest<Product>;
public record GetAllProductQuery(): IRequest<List<Product>>;