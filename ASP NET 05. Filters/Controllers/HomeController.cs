using ASP_NET_05._Filters.Filters;
using ASP_NET_05._Filters.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_NET_05._Filters.Controllers
{
    //[TypeFilter(typeof(ApiKeyQueryAuthorization))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [LastEnterDate]
        public IActionResult Index()
        {
            return View();
        }
        [DateTimeExec]
        public IActionResult Privacy()
        {
            //throw new KeyNotFoundException();
            //int numb = 0;
            //int numb2 = 13 / numb; 
            return View();
        }

        [TypeFilter(typeof(MyAuthorizationFilter))]
        public IActionResult Welcome()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
