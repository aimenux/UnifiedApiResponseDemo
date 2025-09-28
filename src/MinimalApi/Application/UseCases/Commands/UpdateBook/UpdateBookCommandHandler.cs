using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.UpdateBook;

public sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdateBookCommandResponse>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Id = command.Id,
            Title = command.Title,
            Author = command.Author
        };
        var updatedRows = await _bookRepository.UpdateBookAsync(book, cancellationToken);
        return new UpdateBookCommandResponse(updatedRows);
    }
}