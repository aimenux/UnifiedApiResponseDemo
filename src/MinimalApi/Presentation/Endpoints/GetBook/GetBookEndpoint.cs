using MediatR;
using Presentation.Shared;

namespace Presentation.Endpoints.GetBook;

public sealed class GetBookEndpoint : BooksEndpoint
{
    protected override RouteHandlerBuilder MapEndpoint(RouteGroupBuilder group)
    {
        return group
            .MapGet("{id}", async (ISender sender, string id, CancellationToken cancellationToken) =>
            {
                var request = new GetBookRequest(id);
                var query = request.ToQuery();
                var queryResponse = await sender.Send(query, cancellationToken);
                var apiResponse = queryResponse.ToResponse();
                return OkResponse(apiResponse);
            })
            .WithName("GetBook")
            .WithSummary("Get a book")
            .WithDescription("Get a book")
            .Produces<ApiResponse<GetBookResponse>>()
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status404NotFound);
    }
}