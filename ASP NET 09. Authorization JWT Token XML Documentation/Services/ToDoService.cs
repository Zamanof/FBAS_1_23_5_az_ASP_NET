using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Data;
using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs;
using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs.Pagination;
using ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.Services;
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
    public Task<ToDoItemDto> ChangeToDoItemStatusAsync(int id, bool isCompleted)
    {
        var toDo = _context.ToDoItems.FirstOrDefault(x => x.Id == id);
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ToDoItemDto> GetToDoItemAsync(int id)
    {
        var toDo = _context.ToDoItems.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(ConvertToDoItemDto(toDo!))!;
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
        int page,
        int pageSize,
        string? search,
        bool? isCompleted)
    {
        IQueryable<ToDoItem> query = _context.ToDoItems;
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
