using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Endpoints.SearchBooks;

public sealed class SearchBooksEndpoint : BooksEndpoint
{
    protected override RouteHandlerBuilder MapEndpoint(RouteGroupBuilder group)
    {
        return group
            .MapGet("search", async (ISender sender, [FromQuery] string? searchTerm, [FromQuery] int? pageIndex, [FromQuery] int? pageSize, CancellationToken cancellationToken) =>
            {
                var request = new SearchBooksRequest(searchTerm, pageIndex, pageSize);
                var query = request.ToQuery();
                var queryResponse = await sender.Send(query, cancellationToken);
                var apiResponse = queryResponse.ToResponse();
                return OkPagedResponse(apiResponse);
            })
            .WithName("SearchBooks")
            .WithSummary("Search paginated books")
            .WithDescription("Search paginated books")
            .Produces<ApiPagedResponse<List<SearchBooksItemResponse>>>()
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest);
    }
}