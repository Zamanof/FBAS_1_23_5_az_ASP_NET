using ASP_NET_25._Microservice_Example_OrderService.Models;
using MassTransit;

namespace ASP_NET_25._Microservice_Example_OrderService.Services;


public class OrderService
{
    private readonly IBus _bus;

    public OrderService(IBus bus)
    {
        _bus = bus;
    }

    public async Task CreateOrderAsync(Order order)
    {
        await _bus.Publish(order);
    }
}
