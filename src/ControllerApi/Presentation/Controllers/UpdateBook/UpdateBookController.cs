using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers.UpdateBook;

public sealed class UpdateBookController : BooksController
{
    public UpdateBookController(ISender sender) : base(sender)
    {
    }

    [Tags("Books")]
    [EndpointName("UpdateBook")]
    [EndpointSummary("Update a book")]
    [EndpointDescription("Update a book")]
    [ProducesResponseType(typeof(ApiResponse<UpdateBookResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpPut("{id}", Name = nameof(UpdateBook))]
    public async Task<IActionResult> UpdateBook(string id, [FromBody] UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var command = request.ToCommand(id);
        var commandResponse = await Sender.Send(command, cancellationToken);
        var apiResponse = commandResponse.ToResponse();
        return apiResponse.IsUpdated
            ? OkResponse(apiResponse)
            : NotFoundResponse();
    }
}