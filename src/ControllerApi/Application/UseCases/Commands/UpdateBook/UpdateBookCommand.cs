using MediatR;

namespace Application.UseCases.Commands.UpdateBook;

public sealed record UpdateBookCommand(string Id, string Title, string Author) : IRequest<UpdateBookCommandResponse>;