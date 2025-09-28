using MediatR;

namespace Application.UseCases.Commands.DeleteBook;

public sealed record DeleteBookCommand(string Id) : IRequest<DeleteBookCommandResponse>;