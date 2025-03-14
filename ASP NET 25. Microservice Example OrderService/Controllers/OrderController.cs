using ASP_NET_25._Microservice_Example_OrderService.Models;
using ASP_NET_25._Microservice_Example_OrderService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_25._Microservice_Example_OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _service;

    public OrderController(OrderService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<ActionResult> CreateOrder([FromBody] Order order)
    {
        await _service.CreateOrderAsync(order);
        return Ok("Order Craeted and Send");
    }
}
