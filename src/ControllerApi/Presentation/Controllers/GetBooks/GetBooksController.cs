using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers.GetBooks;

public sealed class GetBooksController : BooksController
{
    public GetBooksController(ISender sender) : base(sender)
    {
    }

    [Tags("Books")]
    [EndpointName("GetBooks")]
    [EndpointSummary("Get paginated books")]
    [EndpointDescription("Get paginated books")]
    [ProducesResponseType(typeof(ApiPagedResponse<List<GetBooksItemResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpGet(Name = nameof(GetBooks))]
    public async Task<IActionResult> GetBooks([FromQuery] int? pageIndex, [FromQuery] int? pageSize, CancellationToken cancellationToken)
    {
        var request = new GetBooksRequest(pageIndex, pageSize);
        var query = request.ToQuery();
        var queryResponse = await Sender.Send(query, cancellationToken);
        var apiResponse = queryResponse.ToResponse();
        return OkPagedResponse(apiResponse);
    }
}