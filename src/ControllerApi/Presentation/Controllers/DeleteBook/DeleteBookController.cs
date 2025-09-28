using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers.DeleteBook;

public sealed class DeleteBookController : BooksController
{
    public DeleteBookController(ISender sender) : base(sender)
    {
    }

    [Tags("Books")]
    [EndpointName("DeleteBook")]
    [EndpointSummary("Delete a book")]
    [EndpointDescription("Delete a book")]
    [ProducesResponseType(typeof(ApiResponse<DeleteBookResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpDelete("{id}", Name = nameof(DeleteBook))]
    public async Task<IActionResult> DeleteBook(string id, CancellationToken cancellationToken)
    {
        var request = new DeleteBookRequest(id);
        var command = request.ToCommand();
        var commandResponse = await Sender.Send(command, cancellationToken);
        var apiResponse = commandResponse.ToResponse();
        return apiResponse.IsDeleted
            ? OkResponse(apiResponse)
            : NotFoundResponse();
    }
}