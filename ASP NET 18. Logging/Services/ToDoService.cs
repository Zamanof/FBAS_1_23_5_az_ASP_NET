using ASP_NET_18._Logging.Data;
using ASP_NET_18._Logging.DTOs;
using ASP_NET_18._Logging.DTOs.Pagination;
using ASP_NET_18._Logging.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_18._Logging.Services;
/// <summary>
/// 
/// </summary>
public class ToDoService : IToDoService
{
    private readonly ToDoContext _context;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public ToDoService(ToDoContext context)
    {
        _context = context;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isCompleted"></param>
    /// <returns></returns>
    public Task<ToDoItemDto> ChangeToDoItemStatusAsync(string userId, int id, bool isCompleted)
    {
        var toDo = _context.ToDoItems.FirstOrDefault(x => x.Id == id && x.UserId == userId);
        if (toDo is null) return null!;
        toDo.IsCompleted = isCompleted;
        toDo.UpdatedAt = DateTime.UtcNow;
        _context.SaveChanges();
        return Task.FromResult(ConvertToDoItemDto(toDo));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<ToDoItemDto> CreateToDoAsync(
        string userId, 
        CreateToDoItemRequest request)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null)
        {
            throw new KeyNotFoundException();
        }
        var now = DateTime.UtcNow;

        var item = new ToDoItem()
        {
            Text = request.Text,
            CreatedAt = now,
            UpdatedAt = now,
            IsCompleted = false,
            UserId = userId
        };
        item = _context.ToDoItems.Add(item).Entity;
        await _context.SaveChangesAsync();
        return ConvertToDoItemDto(item);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ToDoItemDto> GetToDoItemAsync(string userId, int id)
    {
        var item = await _context.ToDoItems.FirstOrDefaultAsync(t=> t.Id == id && t.UserId == userId);
        return item is not null
                ?ConvertToDoItemDto(item)
                :null!;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="search"></param>
    /// <param name="isCompleted"></param>
    /// <returns></returns>
    public async Task<PaginationListDto<ToDoItemDto>> GetToDoItemsAsync(
        string userId,
        int page,
        int pageSize,
        string? search,
        bool? isCompleted)
    {
        IQueryable<ToDoItem> query = _context.ToDoItems.Where(t=> t.UserId == userId);
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(item=> item.Text.ToLower().Contains(search));
        }
        if (isCompleted.HasValue)
        {
            query = query.Where(item => item.IsCompleted == isCompleted);
        }

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PaginationListDto<ToDoItemDto>(
            items.Select(item=> ConvertToDoItemDto(item)), 
            new PaginationMeta(page, pageSize, query.Count()));
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
