using ASP_NET_07._ToDo_Web_API_start.Models;
namespace ASP_NET_07._ToDo_Web_API_start.Services;

public interface IToDoService
{
    Task<IEnumerable<ToDoItem>> GetToDoItemsAsync();
    Task<ToDoItem> GetToDoItemAsync(int id);
    Task<ToDoItem> CreateToDoAsync(ToDoItem item);
    Task<ToDoItem> ChangeToDoItemStatusAsync(int id, bool isCompleted);
}
