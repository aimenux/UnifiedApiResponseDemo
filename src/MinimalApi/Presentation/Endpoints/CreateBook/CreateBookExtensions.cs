using Application.UseCases.Commands.CreateBook;

namespace Presentation.Endpoints.CreateBook;

public static class CreateBookExtensions
{
    public static CreateBookCommand ToCommand(this CreateBookRequest request)
    {
        return new CreateBookCommand(request.Title, request.Author);
    }
    
    public static CreateBookResponse ToResponse(this CreateBookCommandResponse commandResponse)
    {
        return new CreateBookResponse(commandResponse.Book.Id, commandResponse.Book.Title, commandResponse.Book.Author);
    }
}