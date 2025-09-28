using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CreateBook;

public sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<CreateBookCommandResponse> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Id = Guid.NewGuid().ToString("N"),
            Title = command.Title,
            Author = command.Author
        };
        await _bookRepository.InsertBookAsync(book, cancellationToken);
        return new CreateBookCommandResponse(book);
    }
}