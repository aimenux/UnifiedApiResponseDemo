using Application.UseCases.Commands.DeleteBook;

namespace Presentation.Controllers.DeleteBook;

public static class DeleteBookExtensions
{
    public static DeleteBookCommand ToCommand(this DeleteBookRequest request)
    {
        return new DeleteBookCommand(request.Id);
    }
    
    public static DeleteBookResponse ToResponse(this DeleteBookCommandResponse commandResponse)
    {
        return new DeleteBookResponse(commandResponse.DeletedRows > 0);
    }
}