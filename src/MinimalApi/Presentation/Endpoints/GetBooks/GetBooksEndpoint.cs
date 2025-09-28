using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Endpoints.GetBooks;

public sealed class GetBooksEndpoint : BooksEndpoint
{
    protected override RouteHandlerBuilder MapEndpoint(RouteGroupBuilder group)
    {
        return group
            .MapGet("", async (ISender sender, [FromQuery] int? pageIndex, [FromQuery] int? pageSize, CancellationToken cancellationToken) =>
            {
                var request = new GetBooksRequest(pageIndex, pageSize);
                var query = request.ToQuery();
                var queryResponse = await sender.Send(query, cancellationToken);
                var apiResponse = queryResponse.ToResponse();
                return OkPagedResponse(apiResponse);
            })
            .WithName("GetBooks")
            .WithSummary("Get paginated books")
            .WithDescription("Get paginated books")
            .Produces<ApiPagedResponse<List<GetBooksItemResponse>>>()
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest);
    }
}