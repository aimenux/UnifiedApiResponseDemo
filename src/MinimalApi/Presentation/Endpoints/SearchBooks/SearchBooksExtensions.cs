using Application.UseCases.Queries.SearchBooks;

namespace Presentation.Endpoints.SearchBooks;

public static class SearchBooksExtensions
{
    public static SearchBooksQuery ToQuery(this SearchBooksRequest request)
    {
        return new SearchBooksQuery(request.SearchTerm, request.PageIndex, request.PageSize);
    }
    
    public static SearchBooksResponse ToResponse(this SearchBooksQueryResponse queryResponse)
    {
        var collection = queryResponse.Books
            .Select(x => new SearchBooksItemResponse(x.Id, x.Title, x.Author));
        
        var pagination = queryResponse.Books.Pagination;
        
        return new SearchBooksResponse(collection, pagination);
    }
}