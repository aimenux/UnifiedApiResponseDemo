using Application;
using Infrastructure;
using Presentation.Extensions;

namespace Presentation;

public sealed class Startup
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder
            .AddPresentation()
            .AddApplication()
            .AddInfrastructure(builder.Configuration);
    }

    public void Configure(WebApplication app)
    {
        app.UseExceptionHandlers();
        app.UseHttpLogging();
        app.UseSwaggerDoc();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapEndpoints();
    }
}