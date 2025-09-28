using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Queries.SearchBooks;

public sealed class SearchBooksQueryHandler : IRequestHandler<SearchBooksQuery, SearchBooksQueryResponse>
{
    private readonly IBookRepository _bookRepository;

    public SearchBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<SearchBooksQueryResponse> Handle(SearchBooksQuery query, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.SearchBooksAsync(query.SearchTerm!, query.PageIndex, query.PageSize, cancellationToken);
        
        return new SearchBooksQueryResponse
        {
            Books = books
        };
    }
}