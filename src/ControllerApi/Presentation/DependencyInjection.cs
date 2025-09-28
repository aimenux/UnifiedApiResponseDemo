using Presentation.Extensions;

namespace Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        builder.AddExceptionHandlers();
        builder.AddControllers();
        builder.AddVersioning();
        builder.AddSwaggerDoc();
        builder.AddRouteOptions();
        builder.AddLogging();
        return services;
    }
    
    private static void AddRouteOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });
    }
}