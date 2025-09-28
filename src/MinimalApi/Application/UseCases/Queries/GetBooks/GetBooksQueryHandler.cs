using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Queries.GetBooks;

public sealed class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, GetBooksQueryResponse>
{
    private readonly IBookRepository _bookRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GetBooksQueryResponse> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetBooksAsync(query.PageIndex, query.PageSize, cancellationToken);
        
        return new GetBooksQueryResponse
        {
            Books = books
        };
    }
}