using MediatR;

namespace Application.UseCases.Queries.SearchBooks;

public sealed record SearchBooksQuery(string? SearchTerm, int PageIndex, int PageSize) : IRequest<SearchBooksQueryResponse>;