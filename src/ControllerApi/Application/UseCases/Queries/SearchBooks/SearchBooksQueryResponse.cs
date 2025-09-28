using Application.Abstractions.Pagination;
using Domain.Entities;

namespace Application.UseCases.Queries.SearchBooks;

public sealed record SearchBooksQueryResponse
{
    public PagedCollection<Book> Books { get; init; } = [];
}