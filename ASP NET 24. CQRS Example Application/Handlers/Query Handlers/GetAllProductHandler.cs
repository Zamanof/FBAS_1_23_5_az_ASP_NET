using ASP_NET_24._CQRS_Example_Domain;
using ASP_NET_24._CQRS_Example_Infrastructure;
using MediatR;

namespace ASP_NET_24._CQRS_Example_Application.Handlers.Query_Handlers;

public  class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<Product>>
{
    private readonly IProductRepository _repository;

    public GetAllProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
