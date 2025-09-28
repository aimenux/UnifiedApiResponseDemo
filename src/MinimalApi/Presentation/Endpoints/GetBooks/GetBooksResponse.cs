using Application.Abstractions.Pagination;

namespace Presentation.Endpoints.GetBooks;

public sealed class GetBooksResponse : PagedCollection<GetBooksItemResponse>
{
    public GetBooksResponse()
    {
    }

    public GetBooksResponse(IEnumerable<GetBooksItemResponse> collection, Paging pagination) : base(collection, pagination)
    {
    }
}

public sealed record GetBooksItemResponse(string Id, string Title, string Author);