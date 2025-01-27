using ASP_NET_07._ToDo_Web_API_start.Models;
using ASP_NET_07._ToDo_Web_API_start.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_07._ToDo_Web_API_start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Get()
        {
            return (await _service.GetToDoItemsAsync()).ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> Get(int id)
        {
            var item = await _service.GetToDoItemAsync(id);
            return item is not null ? item : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> Post(ToDoItem item)
        {
            return await _service.CreateToDoAsync(item);
        }
    }
}

/*
 * MVC:
    Create:
        GET      /products/create           -> html
        POST     /products/create           -> html
    
    Update:
        GET      /products/update/{id}      -> html
        POST     /products/update/{id}      -> html

    Delete:
        GET      /products/delete/{id}      -> html
        POST     /products/delete/{id}      -> html

    GetAll:
        GET      /products/index            -> html

    GetOne:
        GET      /products/index/{id}       -> html


* API:
    Create:
       POST     /products                   -> json

    Update:                                    
       PUT     /products/{id}               -> json

    Delete:                                    
       DELETE     /products/{id}            -> json
                                               
    GetAll:                                    
        GET      /products                  -> json
                                               
    GetOne:                                    
        GET      /products/{id}             -> json
 
 
 */