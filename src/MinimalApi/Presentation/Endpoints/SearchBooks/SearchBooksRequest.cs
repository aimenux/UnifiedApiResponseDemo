using Presentation.Shared;

namespace Presentation.Endpoints.SearchBooks;

public sealed record SearchBooksRequest
{
    public string? SearchTerm { get; }
    public int PageIndex { get; }
    public int PageSize { get; }
    public SearchBooksRequest(string? searchTerm, int? pageIndex, int? pageSize)
    {
        SearchTerm = searchTerm;
        PageIndex = pageIndex ?? ApiConstants.Pagination.DefaultPageIndex;
        PageSize = pageSize ?? ApiConstants.Pagination.DefaultPageSize;
    }
}