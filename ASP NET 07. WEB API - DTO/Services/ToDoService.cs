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
        var toDo = _context.ToDoItems.FirstOrDefault(x => x.Id == id);
        if (toDo is null) return null!;
        toDo.IsCompleted = isCompleted;
        toDo.UpdatedAt = DateTime.UtcNow;
        _context.SaveChanges();
        return Task.FromResult(ConvertToDoItemDto(toDo));
    }

    public Task<ToDoItemDto> CreateToDoAsync(CreateToDoItemRequest request)
    {
        var item = new ToDoItem()
        {
            Text = request.Text,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsCompleted = false
        };
        _context.ToDoItems.Add(item);
        _context.SaveChanges();
        return Task.FromResult(ConvertToDoItemDto(item));
    }

    public Task<ToDoItemDto> GetToDoItemAsync(int id)
    {
        var toDo = _context.ToDoItems.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(ConvertToDoItemDto(toDo!))!;
    }

    public Task<IEnumerable<ToDoItemDto>> GetToDoItemsAsync()
    {
        var todo = _context.ToDoItems.ToList();
        return Task.FromResult(todo.Select(ConvertToDoItemDto));
    }

    private ToDoItemDto ConvertToDoItemDto(ToDoItem item)
    {
        var toDoItemDto = new ToDoItemDto()
        {
            Id = item.Id,
            Text = item.Text,
            CreatedAt = item.CreatedAt,
            IsCompleted = item.IsCompleted
        };
        return toDoItemDto;
    }
}
