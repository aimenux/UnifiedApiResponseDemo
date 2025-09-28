using Domain.Entities;

namespace Application.UseCases.Commands.CreateBook;

public sealed record CreateBookCommandResponse(Book Book);