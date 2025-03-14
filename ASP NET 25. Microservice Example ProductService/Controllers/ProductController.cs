using ASP_NET_25._Microservice_Example_ProductService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_25._Microservice_Example_ProductService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
        var products = await _service.GetAllProductsAsync();
        return Ok(products);
    }
}
