using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Queries.GetBook;

public sealed class GetBookQueryHandler : IRequestHandler<GetBookQuery, GetBookQueryResponse>
{
    private readonly IBookRepository _bookRepository;

    public GetBookQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GetBookQueryResponse> Handle(GetBookQuery query, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookByIdAsync(query.Id, cancellationToken);
        return new GetBookQueryResponse(book);
    }
}