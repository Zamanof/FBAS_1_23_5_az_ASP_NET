using MassTransit;

namespace ASP_NET_25._Microservice_Example_ProductService;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    public async Task Consume(ConsumeContext<OrderCreated> context)
    {
        var order = context.Message;
        await Console.Out.WriteLineAsync($"[ProductService] Order: {order.OrderId}: {order.ProductName} - {order.Quantity}");
    }
}
