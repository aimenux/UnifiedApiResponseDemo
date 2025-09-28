using MediatR;
using Presentation.Controllers.DeleteBook;
using Presentation.Shared;

namespace Presentation.Endpoints.DeleteBook;

public sealed class DeleteBookEndpoint : BooksEndpoint
{
    protected override RouteHandlerBuilder MapEndpoint(RouteGroupBuilder group)
    {
        return group
            .MapDelete("{id}", async (ISender sender, string id, CancellationToken cancellationToken) =>
            {
                var request = new DeleteBookRequest(id);
                var command = request.ToCommand();
                var commandResponse = await sender.Send(command, cancellationToken);
                var apiResponse = commandResponse.ToResponse();
                return apiResponse.IsDeleted
                    ? OkResponse(apiResponse)
                    : NotFoundResponse();
            })
            .WithName("DeleteBook")
            .WithSummary("Delete a book")
            .WithDescription("Delete a book")
            .Produces<ApiResponse<DeleteBookResponse>>()
            .Produces<ApiResponse>(StatusCodes.Status404NotFound);
    }
}