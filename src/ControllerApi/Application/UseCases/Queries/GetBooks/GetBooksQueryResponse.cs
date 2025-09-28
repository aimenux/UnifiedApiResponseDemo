using Application.Abstractions.Pagination;
using Domain.Entities;

namespace Application.UseCases.Queries.GetBooks;

public sealed record GetBooksQueryResponse
{
    public PagedCollection<Book> Books { get; init; } = [];
}