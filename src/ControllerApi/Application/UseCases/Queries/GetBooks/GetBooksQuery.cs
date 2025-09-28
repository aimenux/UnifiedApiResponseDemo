using MediatR;

namespace Application.UseCases.Queries.GetBooks;

public sealed record GetBooksQuery(int PageIndex, int PageSize) : IRequest<GetBooksQueryResponse>;