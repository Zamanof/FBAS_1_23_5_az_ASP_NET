using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_NET_03._Razor_Pages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }



        public void OnGet(Person person)
        {
            ViewData["Name"] = person.Name;
            ViewData["Age"] = person.Age;
        }


        public string Foo(string str)
        {
            return str.Replace('a', 'u');
        }
    }
}
