using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_22._ToDo_WebApi_For_Unit_Test.DTOs;

public class ToDoQueryFilters
{
    [FromQuery(Name ="search")]
    public string? Search {  get; set; }

    [FromQuery(Name ="completed")]
    public bool? isCompleted { get; set; }
}
