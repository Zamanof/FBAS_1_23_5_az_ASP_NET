namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs.Pagination;
/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class PaginationListDto<T>
{
    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<T> Items { get;}
    /// <summary>
    /// 
    /// </summary>
    public PaginationMeta Meta { get;}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="items"></param>
    /// <param name="meta"></param>
    public PaginationListDto(IEnumerable<T> items, PaginationMeta meta)
    {
        Items = items;
        Meta = meta;
    }
}
