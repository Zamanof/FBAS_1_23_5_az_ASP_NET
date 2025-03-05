﻿namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.Models;
public class ToDoItem
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string UserId { get; set; }
    public virtual AppUser User { get; set; }
}
