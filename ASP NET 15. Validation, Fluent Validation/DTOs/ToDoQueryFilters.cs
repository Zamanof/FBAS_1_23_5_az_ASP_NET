using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_15._Validation__Fluent_Validation.DTOs;

public class ToDoQueryFilters
{
    [FromQuery(Name ="search")]
    public string? Search {  get; set; }

    [FromQuery(Name ="completed")]
    public bool? isCompleted { get; set; }
}
