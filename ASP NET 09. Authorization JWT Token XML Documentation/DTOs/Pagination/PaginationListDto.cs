namespace ASP_NET_09._Authorization_JWT_Token_XML_Documentation.DTOs.Pagination;

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
