using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Presentation.Endpoints;

namespace Presentation.Extensions;

public static class EndpointsExtensions
{
    private static readonly Type EndpointType = typeof(IEndpoint);
    
    private static readonly Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
    
    public static void AddEndpoints(this WebApplicationBuilder builder)
    {
        var serviceDescriptors = CurrentAssembly
            .GetTypes()
            .Where(IsEndpointType)
            .Select(type => ServiceDescriptor.Transient(EndpointType, type));
        
        builder.Services.TryAddEnumerable(serviceDescriptors);
    }
    
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.Services.GetServices<IEndpoint>();
        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }
    }

    private static bool IsEndpointType(Type type)
    {
        return EndpointType.IsAssignableFrom(type) && type is { IsClass: true, IsAbstract: false };
    }
}