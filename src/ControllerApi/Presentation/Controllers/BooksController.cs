using System.Net.Mime;
using Application.Abstractions.Pagination;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers;

[ApiController]
[ApiVersion(ApiConstants.Versions.V1)]
[Route(ApiConstants.Routes.BooksRoute)]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public abstract class BooksController : ControllerBase
{
    protected readonly ISender Sender;

    protected BooksController(ISender sender)
    {
        Sender = sender;
    }
    
    protected ObjectResult OkResponse<T>(T data)
    {
        var response = ApiResponse<T>.SuccessResponse(data);
        return Ok(response);
    }
    
    protected ObjectResult OkPagedResponse<T>(PagedCollection<T> data)
    {
        var response = ApiPagedResponse<IReadOnlyCollection<T>>.SuccessResponse(data, data.Pagination);
        return Ok(response);
    }
    
    protected ObjectResult CreatedResponse<T>(string? routeName, object? routeValues, T data)
    {
        var response = ApiResponse<T>.SuccessResponse(data);
        return CreatedAtRoute(routeName, routeValues, response);
    }
    
    protected ObjectResult NotFoundResponse()
    {
        var response = ApiResponse.ErrorResponse();
        return NotFound(response);
    }
}