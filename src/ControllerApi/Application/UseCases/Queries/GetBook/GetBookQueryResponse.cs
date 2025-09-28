using Domain.Entities;

namespace Application.UseCases.Queries.GetBook;

public sealed record GetBookQueryResponse(Book? Book);