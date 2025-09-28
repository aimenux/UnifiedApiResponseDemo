using MediatR;

namespace Application.UseCases.Commands.CreateBook;

public sealed record CreateBookCommand(string Title, string Author) : IRequest<CreateBookCommandResponse>;