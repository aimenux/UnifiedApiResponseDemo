using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers.CreateBook;

public sealed class CreateBookController : BooksController
{
    public CreateBookController(ISender sender) : base(sender)
    {
    }

    [Tags("Books")]
    [EndpointName("CreateBook")]
    [EndpointSummary("Create a book")]
    [EndpointDescription("Create a book")]
    [ProducesResponseType(typeof(ApiResponse<CreateBookResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpPost(Name = nameof(CreateBook))]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request, CancellationToken cancellationToken)
    {
        var command = request.ToCommand();
        var commandResponse = await Sender.Send(command, cancellationToken);
        var apiResponse = commandResponse.ToResponse();
        return CreatedResponse("GetBook", new { version = ApiConstants.Versions.V1, id = apiResponse.Id }, apiResponse);
    }
}