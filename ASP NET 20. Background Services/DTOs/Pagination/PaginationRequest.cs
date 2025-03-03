using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP_NET_20._Background_Services.DTOs.Pagination;
/// <summary>
/// Pagination request
/// </summary>
public class PaginationRequest
{
    /// <summary>
    /// Page number
    /// </summary>
    /// <example>1</example>
    [Required]
    [FromQuery(Name ="page")]
    [Range(1, int.MaxValue)]
    public int Page {  get; set; } = 1;

    /// <summary>
    /// Page size - How many items in one page
    /// </summary>
    /// <example>10</example>
    [Required]
    [FromQuery(Name = "pageSize")]
    [Range(1, int.MaxValue)]
    public int PageSize { get; set; } = 10;
}
