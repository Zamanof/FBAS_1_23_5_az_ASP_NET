using ASP_NET_15._Validation__Fluent_Validation.DTOs;
using ASP_NET_15._Validation__Fluent_Validation.DTOs.Pagination;


namespace ASP_NET_15._Validation__Fluent_Validation.Services;

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

