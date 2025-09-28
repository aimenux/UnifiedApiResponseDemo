using Application.UseCases.Queries.GetBook;

namespace Presentation.Endpoints.GetBook;

public static class GetBookExtensions
{
    public static GetBookQuery ToQuery(this GetBookRequest request)
    {
        return new GetBookQuery(request.Id);
    }
    
    public static GetBookResponse? ToResponse(this GetBookQueryResponse queryResponse)
    {
        var book = queryResponse.Book;

        return book is null 
            ? null 
            : new GetBookResponse(book.Id, book.Title, book.Author);
    }
}