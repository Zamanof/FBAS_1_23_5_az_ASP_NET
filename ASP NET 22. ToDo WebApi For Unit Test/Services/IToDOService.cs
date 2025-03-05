using ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs;
using ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs.Pagination;


namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.Services;

public interface IToDoService
{
    Task<PaginationListDto<ToDoItemDto>> GetToDoItemsAsync(
        string userId,
        int page,
        int pageSize,
        string? search,
        bool? isCompleted);
    Task<ToDoItemDto> GetToDoItemAsync(
        string userId,
        int id);
    Task<ToDoItemDto> CreateToDoAsync(
        string userId,
        CreateToDoItemRequest request);
    Task<ToDoItemDto> ChangeToDoItemStatusAsync(
        string userId, 
        int id, 
        bool isCompleted);
}

