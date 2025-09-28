using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Commands.DeleteBook;

public sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, DeleteBookCommandResponse>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        var deletedRows = await _bookRepository.DeleteBookAsync(command.Id, cancellationToken);
        return new DeleteBookCommandResponse(deletedRows);
    }
}