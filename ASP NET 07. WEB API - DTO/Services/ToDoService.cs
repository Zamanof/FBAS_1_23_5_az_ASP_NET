using ASP_NET_07._WEB_API___DTO.Data;
using ASP_NET_07._WEB_API___DTO.DTOs;
using ASP_NET_07._WEB_API___DTO.Models;

namespace ASP_NET_07._WEB_API___DTO.Services;

public class ToDoService : IToDoService
{
    private readonly ToDoContext _context;
    public ToDoService(ToDoContext context)
    {
        _context = context;
    }

    public Task<ToDoItemDto> ChangeToDoItemStatusAsync(int id, bool isCompleted)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItemDto> CreateToDoAsync(CreateToDoItemRequest request)
    {
        var item = new ToDoItemDto()
        {
            Text = request.Text,
            CreatedAt = DateTime.UtcNow,
            IsCompleted = false
        };

        var toDo = new ToDoItem()
        {
            Text = request.Text,
            CreatedAt = DateTime.UtcNow,
            IsCompleted = false,
            UpdatedAt = DateTime.UtcNow
        };
        _context.ToDoItems.Add(toDo);
        _context.SaveChanges();
        return Task.FromResult(item);
    }

    public Task<ToDoItemDto> GetToDoItemAsync(int id)
    {
        var toDo = _context.ToDoItems.FirstOrDefault(t => t.Id == id);
        var item = new ToDoItemDto()
        {
            Id = toDo.Id,
            Text = toDo.Text,
            CreatedAt = toDo.CreatedAt,
            IsCompleted = toDo.IsCompleted,
        };
        return Task.FromResult(item)!;
    }

    public Task<IEnumerable<ToDoItemDto>> GetToDoItemsAsync()
    {
        var todo = _context.ToDoItems.ToList();
        var items = new List<ToDoItemDto>();
        foreach (var toDo in todo)
        {
            var item = new ToDoItemDto()
            {
                Id = toDo.Id,
                Text = toDo.Text,
                CreatedAt = toDo.CreatedAt,
                IsCompleted = toDo.IsCompleted,
            };
            items.Add(item);
        }

        return Task.FromResult<IEnumerable<ToDoItemDto>>(items);
    }
}
