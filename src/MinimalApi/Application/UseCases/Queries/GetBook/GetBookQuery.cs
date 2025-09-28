using MediatR;

namespace Application.UseCases.Queries.GetBook;

public sealed record GetBookQuery(string Id) : IRequest<GetBookQueryResponse>;