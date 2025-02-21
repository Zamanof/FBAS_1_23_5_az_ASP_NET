using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_11._Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy ="CanTest")]
public class TestController : ControllerBase
{
    [HttpGet("test")]
    public async Task<ActionResult> Test()
    {
        return Ok("It works!!!");
    }
}
