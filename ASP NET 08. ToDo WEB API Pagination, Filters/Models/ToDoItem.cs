﻿namespace ASP_NET_08._ToDo_WEB_API_Pagination__Filters.Models;
public class ToDoItem
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
