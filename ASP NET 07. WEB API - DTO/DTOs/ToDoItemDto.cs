namespace ASP_NET_07._WEB_API___DTO.DTOs;

public class ToDoItemDto
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
