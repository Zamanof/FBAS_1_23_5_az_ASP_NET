﻿using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_08._ToDo_WEB_API_Pagination__Filters.DTOs;

public class ToDoQueryFilters
{
    [FromQuery(Name ="search")]
    public string? Search {  get; set; }

    [FromQuery(Name ="completed")]
    public bool? isCompleted { get; set; }
}
