using Application.UseCases.Commands.UpdateBook;

namespace Presentation.Controllers.UpdateBook;

public static class UpdateBookExtensions
{
    public static UpdateBookCommand ToCommand(this UpdateBookRequest request, string id)
    {
        return new UpdateBookCommand(id, request.Title, request.Author);
    }
    
    public static UpdateBookResponse ToResponse(this UpdateBookCommandResponse commandResponse)
    {
        return new UpdateBookResponse(commandResponse.UpdatedRows > 0);
    }
}