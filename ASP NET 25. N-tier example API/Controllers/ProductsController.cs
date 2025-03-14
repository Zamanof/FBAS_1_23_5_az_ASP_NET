using ASP_NET_25._N_tier_example_BLL.Services;
using ASP_NET_25._N_tier_example_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_25._N_tier_example_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult GetProducts()
    {
        List<Product> products = _service.GetAllProducts();
        return Ok(products);
    }
}
