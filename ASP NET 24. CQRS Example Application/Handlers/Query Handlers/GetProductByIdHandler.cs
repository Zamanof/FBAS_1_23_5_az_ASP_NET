using ASP_NET_24._CQRS_Example_Domain;
using ASP_NET_24._CQRS_Example_Infrastructure;
using MediatR;

namespace ASP_NET_24._CQRS_Example_Application.Handlers.Query_Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
