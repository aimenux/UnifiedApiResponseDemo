using Application.UseCases.Queries.GetBooks;

namespace Presentation.Endpoints.GetBooks;

public static class GetBooksExtensions
{
    public static GetBooksQuery ToQuery(this GetBooksRequest request)
    {
        return new GetBooksQuery(request.PageIndex, request.PageSize);
    }
    
    public static GetBooksResponse ToResponse(this GetBooksQueryResponse queryResponse)
    {
        var collection = queryResponse.Books
            .Select(x => new GetBooksItemResponse(x.Id, x.Title, x.Author));
        
        var pagination = queryResponse.Books.Pagination;
        
        return new GetBooksResponse(collection, pagination);
    }
}