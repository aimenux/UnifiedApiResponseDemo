using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Presentation.Shared;

namespace Presentation.Exceptions;

public sealed class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if(exception is not ValidationException validationException)
        {
            return false;
        }
        
        var apiResponse = CreateApiResponse(validationException);
        
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        
        await httpContext.Response.WriteAsJsonAsync(apiResponse, cancellationToken: cancellationToken);

        return true;
    }
    
    private static ApiResponse CreateApiResponse(ValidationException validationException)
    {
        var errors = validationException.Errors
            .Select(x => x.ErrorMessage)
            .ToList();

        return ApiResponse.ErrorResponse(errors);
    }
}