using ASP_NET_24._CQRS_Example_Domain;
using ASP_NET_24._CQRS_Example_Infrastructure;
using MediatR;

namespace ASP_NET_24._CQRS_Example_Application.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price);
        await _repository.AddAsync(product);
        return product.Id;
    }
}
