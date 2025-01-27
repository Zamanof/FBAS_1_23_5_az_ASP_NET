using ASP_NET_07._WEB_API___DTO.DTOs;


namespace ASP_NET_07._WEB_API___DTO.Services;

public interface IToDoService
{
    Task<IEnumerable<ToDoItemDto>> GetToDoItemsAsync();
    Task<ToDoItemDto> GetToDoItemAsync(int id);
    Task<ToDoItemDto> CreateToDoAsync(CreateToDoItemRequest request);
    Task<ToDoItemDto> ChangeToDoItemStatusAsync(int id, bool isCompleted);
}

