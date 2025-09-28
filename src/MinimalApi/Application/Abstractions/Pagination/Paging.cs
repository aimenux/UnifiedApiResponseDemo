namespace Application.Abstractions.Pagination;

public sealed record Paging
{
    public Paging(int pageIndex = 1, int pageSize = 10, int totalCount = 0)
    {
        PageIndex = pageIndex;
        PageSize = pageSize < 0 ? 0 : pageSize;
        TotalCount = totalCount;
        TotalPages = PageSize == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize);
        HasPreviousPage = PageIndex > 1; 
        HasNextPage = PageIndex < TotalPages;
    }

    public int PageIndex { get; private init; }
    public int PageSize { get; private init; }
    public int TotalCount { get; private init; }
    public int TotalPages { get; private init; }
    public bool HasPreviousPage { get; private init; }
    public bool HasNextPage { get; private init; }
}