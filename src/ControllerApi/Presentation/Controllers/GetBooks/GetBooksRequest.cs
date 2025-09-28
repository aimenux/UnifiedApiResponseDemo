using Presentation.Shared;

namespace Presentation.Controllers.GetBooks;

public sealed record GetBooksRequest
{
    public int PageIndex { get; }
    public int PageSize { get; }
    public GetBooksRequest(int? pageIndex, int? pageSize)
    {
        PageIndex = pageIndex ?? ApiConstants.Pagination.DefaultPageIndex;
        PageSize = pageSize ?? ApiConstants.Pagination.DefaultPageSize;
    }
}