
using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs;
using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs.Pagination;
using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Controllers;

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
    public async Task<ActionResult<PaginationListDto<ToDoItemDto>>> Get(
        [FromQuery] PaginationRequest request,
        [FromQuery] ToDoQueryFilters filters)
    {
        return await _service.GetToDoItemsAsync(
            request.Page,
            request.PageSize,
            filters.Search,
            filters.isCompleted
            );
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItemDto>> Get(int id)
    {
        var item = await _service.GetToDoItemAsync(id);
        return item is not null ? item : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItemDto>> Post([FromBody] CreateToDoItemRequest request)
    {
        var createdItem = await _service.CreateToDoAsync(request);
        return  createdItem;
    }

    [HttpPatch("{id}/status")]
    public async Task<ActionResult<ToDoItemDto>> Patch(int id, [FromBody] bool isCompleted)
    {
        var toDoItem = await _service.ChangeToDoItemStatusAsync(id, isCompleted);
        return toDoItem is not null ? toDoItem: NotFound();
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
       PATCH    /products/{id}              -> json

    Delete:                                    
       DELETE     /products/{id}            -> json
                                               
    GetAll:                                    
        GET      /products                  -> json
                                               
    GetOne:                                    
        GET      /products/{id}             -> json
 
 
 */
