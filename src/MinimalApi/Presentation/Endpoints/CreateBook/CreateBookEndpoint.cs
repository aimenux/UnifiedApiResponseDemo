using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Endpoints.CreateBook;

public sealed class CreateBookEndpoint : BooksEndpoint
{
    protected override RouteHandlerBuilder MapEndpoint(RouteGroupBuilder group)
    {
        return group
            .MapPost("", async (ISender sender, [FromBody] CreateBookRequest request, CancellationToken cancellationToken) =>
            {
                var command = request.ToCommand();
                var commandResponse = await sender.Send(command, cancellationToken);
                var apiResponse = commandResponse.ToResponse();
                return CreatedResponse("GetBook", new { version = ApiConstants.Versions.V1, id = apiResponse.Id }, apiResponse);
            })
            .WithName("CreateBook")
            .WithSummary("Create a book")
            .WithDescription("Create a book")
            .Produces<ApiResponse<CreateBookResponse>>(StatusCodes.Status201Created)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest);
    }
}