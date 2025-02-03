using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs;
using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs.Pagination;


namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Services;

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

