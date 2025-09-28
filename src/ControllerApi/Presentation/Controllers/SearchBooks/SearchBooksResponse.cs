using Application.Abstractions.Pagination;

namespace Presentation.Controllers.SearchBooks;

public sealed class SearchBooksResponse : PagedCollection<SearchBooksItemResponse>
{
    public SearchBooksResponse()
    {
    }

    public SearchBooksResponse(IEnumerable<SearchBooksItemResponse> collection, Paging pagination) : base(collection, pagination)
    {
    }
}

public sealed record SearchBooksItemResponse(string Id, string Title, string Author);