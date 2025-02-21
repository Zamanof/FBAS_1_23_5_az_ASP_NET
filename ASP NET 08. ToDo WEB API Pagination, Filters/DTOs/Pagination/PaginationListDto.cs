namespace ASP_NET_08._ToDo_WEB_API_Pagination__Filters.DTOs.Pagination;

public class PaginationListDto<T>
{
    public IEnumerable<T> Items { get;}
    public PaginationMeta Meta { get;}

    public PaginationListDto(IEnumerable<T> items, PaginationMeta meta)
    {
        Items = items;
        Meta = meta;
    }
}
