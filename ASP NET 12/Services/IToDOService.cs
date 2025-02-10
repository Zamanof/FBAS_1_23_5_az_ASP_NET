using ASP_NET_12.DTOs;
using ASP_NET_12.DTOs.Pagination;


namespace ASP_NET_12.Services;

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

