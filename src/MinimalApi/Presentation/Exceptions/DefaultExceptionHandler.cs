using Microsoft.AspNetCore.Diagnostics;
using Presentation.Shared;

namespace Presentation.Exceptions;

public sealed class DefaultExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var apiResponse = CreateApiResponse(exception);

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        
        await httpContext.Response.WriteAsJsonAsync(apiResponse, cancellationToken: cancellationToken);

        return true;
    }
    
    private static ApiResponse CreateApiResponse(Exception exception)
    {
        return ApiResponse.ErrorResponse([exception.Message]);
    }
}