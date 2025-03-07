using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;


namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Policy ="CanTest")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly IMemoryCache _memoryCache;
    private readonly RoleManager<IdentityRole> _roleManager;

    public TestController(ILogger<TestController> logger, IMemoryCache memoryCache, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _memoryCache = memoryCache;
        _roleManager = roleManager;
    }

    //[ResponseCache(Duration = 30)]
    [HttpGet("test")]
    public async Task<ActionResult> Test()
    {
        if (_memoryCache.TryGetValue("cached_data", out var cachedData))
        {
            return Ok(cachedData);
        }
        else
        {
            await Task.Delay(3000);
            var data = "It works";
            _memoryCache.Set("cached_data", data, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow =  TimeSpan.FromSeconds(10),
                SlidingExpiration = TimeSpan.FromSeconds(5),
                Priority = CacheItemPriority.High
            });
            return Ok(data);

        }
        //await Task.Delay(3000);
        //_logger.Log(LogLevel.Information, "It's ok-> 200");
        //_logger.LogCritical("It's ok-> 200");
        //_logger.LogCritical(new NullReferenceException(), "Null");
        //throw new NotImplementedException();

        return Ok("It works!!!");
    }

    [HttpPost("Add Role")]
    public async Task<ActionResult> AddRole(string roleName)
    {
        if (!_roleManager.RoleExistsAsync(roleName).Result)
        {
            var role = new IdentityRole(roleName);
            await _roleManager.CreateAsync(role);
        }
        return Ok();
    }
}
