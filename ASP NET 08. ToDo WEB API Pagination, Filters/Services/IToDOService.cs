using ASP_NET_08._ToDo_WEB_API_Pagination__Filters.DTOs;
using ASP_NET_08._ToDo_WEB_API_Pagination__Filters.DTOs.Pagination;


namespace ASP_NET_08._ToDo_WEB_API_Pagination__Filters.Services;

public interface IToDoService
{
    Task<PaginationListDto<ToDoItemDto>> GetToDoItemsAsync(
        int page,
        int pageSize,
        string? search,
        bool? isCompleted);
    Task<ToDoItemDto> GetToDoItemAsync(int id);
    Task<ToDoItemDto> CreateToDoAsync(CreateToDoItemRequest request);
    Task<ToDoItemDto> ChangeToDoItemStatusAsync(int id, bool isCompleted);
}

