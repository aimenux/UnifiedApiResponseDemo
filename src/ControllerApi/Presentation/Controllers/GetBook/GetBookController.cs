using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers.GetBook;

public sealed class GetBookController : BooksController
{
    public GetBookController(ISender sender) : base(sender)
    {
    }

    [Tags("Books")]
    [EndpointName("GetBook")]
    [EndpointSummary("Get a book")]
    [EndpointDescription("Get a book")]
    [ProducesResponseType(typeof(ApiResponse<GetBookResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpGet("{id}", Name = nameof(GetBook))]
    public async Task<IActionResult> GetBook(string id, CancellationToken cancellationToken)
    {
        var request = new GetBookRequest(id);
        var query = request.ToQuery();
        var queryResponse = await Sender.Send(query, cancellationToken);
        var apiResponse = queryResponse.ToResponse();
        return apiResponse is null
            ? NotFoundResponse()
            : OkResponse(apiResponse);
    }
}