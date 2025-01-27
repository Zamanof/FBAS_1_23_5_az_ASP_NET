using ASP_NET_07._ToDo_Web_API_start.Models;

namespace ASP_NET_07._ToDo_Web_API_start.Services;

public class ToDoService : IToDoService
{
    private readonly Dictionary<int, ToDoItem> _items = new();
    private int _nextId = 1;

    public Task<ToDoItem> ChangeToDoItemStatusAsync(int id, bool isCompleted)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItem> CreateToDoAsync(ToDoItem item)
    {
        item.Id = _nextId++;
        _items.Add(item.Id, item);
        return Task.FromResult(item);
    }

    public Task<ToDoItem> GetToDoItemAsync(int id)
    {
        return Task.FromResult(_items.GetValueOrDefault(id));
    }

    public Task<IEnumerable<ToDoItem>> GetToDoItemsAsync()
    {
        return Task.FromResult<IEnumerable<ToDoItem>>(_items.Values);
    }
}
