
using ASP_NET_11._Identity.DTOs;
using ASP_NET_11._Identity.DTOs.Pagination;
using ASP_NET_11._Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_11._Identity.Controllers;

// admin
// moderator
// user
// guest

// admin (CanEdit, CanDelete, CanCreate, CanView)
// moderator  (CanEdit, CanView)
// user  (CanView)
// guest
// permissons CanEdit, CanDelete, CanCreate, CanView


/// <summary>
/// ToDo API main Controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _service;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="service"></param>
    public ToDoController(IToDoService service)
    {
        _service = service;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="filters"></param>
    /// <returns></returns>
    [HttpGet]
    //[Authorize(Policy = "CanView")]
    //[Authorize(Roles ="admin, moderator, user")]
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[Authorize(Policy ="CanView")]
    public async Task<ActionResult<ToDoItemDto>> Get(int id)
    {
        var item = await _service.GetToDoItemAsync(id);
        return item is not null ? item : NotFound();
    }


    /// <summary>
    /// Create ToDo Item
    /// </summary>
    /// <param name="request"></param>
    /// <response code="201">Success</response>
    /// <response code="409">Task already created</response>
    /// <response code="403">Forbiden</response>
    [HttpPost]
    //[Authorize(Roles = "admin")]
    //[Authorize(Policy = "CanCreate")]
    public async Task<ActionResult<ToDoItemDto>> Post([FromBody] CreateToDoItemRequest request)
    {
        var createdItem = await _service.CreateToDoAsync(request);
        return  createdItem;
    }


    /// <summary>
    /// Change ToDo Item Status
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isCompleted"></param>
    /// <returns>ToDo Item with changed status</returns>
    [HttpPatch("{id}/status")]
    //[Authorize(Roles ="admin, moderator")]
    //[Authorize(Policy = "CanEdit")]
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
