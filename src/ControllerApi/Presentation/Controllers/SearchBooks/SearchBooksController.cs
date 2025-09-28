using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers.SearchBooks;

public sealed class SearchBooksController : BooksController
{
    public SearchBooksController(ISender sender) : base(sender)
    {
    }

    [Tags("Books")]
    [EndpointName("SearchBooks")]
    [EndpointSummary("Search paginated books")]
    [EndpointDescription("Search paginated books")]
    [ProducesResponseType(typeof(ApiPagedResponse<List<SearchBooksItemResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpGet("search", Name = nameof(SearchBooks))]
    public async Task<IActionResult> SearchBooks([FromQuery] string? searchTerm, [FromQuery] int? pageIndex, [FromQuery] int? pageSize, CancellationToken cancellationToken)
    {
        var request = new SearchBooksRequest(searchTerm, pageIndex, pageSize);
        var query = request.ToQuery();
        var queryResponse = await Sender.Send(query, cancellationToken);
        var apiResponse = queryResponse.ToResponse();
        return OkPagedResponse(apiResponse);
    }
}