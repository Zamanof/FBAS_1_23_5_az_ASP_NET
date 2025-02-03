using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs;

public class ToDoQueryFilters
{
    [FromQuery(Name ="search")]
    public string? Search {  get; set; }

    [FromQuery(Name ="completed")]
    public bool? isCompleted { get; set; }
}
