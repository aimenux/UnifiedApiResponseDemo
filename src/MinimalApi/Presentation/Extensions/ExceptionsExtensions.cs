using Presentation.Exceptions;

namespace Presentation.Extensions;

public static class ExceptionsExtensions
{
    public static void AddExceptionHandlers(this WebApplicationBuilder builder)
    {
        builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
        builder.Services.AddExceptionHandler<DefaultExceptionHandler>();
    }
    
    public static void UseExceptionHandlers(this WebApplication app)
    {
        app.UseExceptionHandler(opt => { });
    }
}