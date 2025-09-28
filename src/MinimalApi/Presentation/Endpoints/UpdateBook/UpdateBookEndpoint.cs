using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Endpoints.UpdateBook;

public sealed class UpdateBookEndpoint : BooksEndpoint
{
    protected override RouteHandlerBuilder MapEndpoint(RouteGroupBuilder group)
    {
        return group
            .MapPut("{id}", async (ISender sender, string id, [FromBody] UpdateBookRequest request, CancellationToken cancellationToken) =>
            {
                var command = request.ToCommand(id);
                var commandResponse = await sender.Send(command, cancellationToken);
                var apiResponse = commandResponse.ToResponse();
                return apiResponse.IsUpdated
                    ? OkResponse(apiResponse)
                    : NotFoundResponse();
            })
            .WithName("UpdateBook")
            .WithSummary("Update a book")
            .WithDescription("Update a book")
            .Produces<ApiResponse<UpdateBookResponse>>()
            .Produces<ApiResponse>(StatusCodes.Status404NotFound);
    }
}