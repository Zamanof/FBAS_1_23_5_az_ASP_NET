﻿namespace ASP_NET_12.DTOs.Pagination;
/// <summary>
/// 
/// </summary>
public class PaginationMeta
{
    /// <summary>
    /// 
    /// </summary>
    public int Page {  get;}
    /// <summary>
    /// 
    /// </summary>
    public int PageSize { get;}
    /// <summary>
    /// 
    /// </summary>
    public int TotalPages { get;}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="totalCount"></param>

    public PaginationMeta(int page, int pageSize, int totalCount)
    {
        Page = page;
        PageSize = pageSize;
        TotalPages = Convert.ToInt32(Math.Ceiling(1.0 * totalCount/ pageSize));
    }
}
