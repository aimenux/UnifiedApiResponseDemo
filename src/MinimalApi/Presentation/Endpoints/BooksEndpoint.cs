using Application.Abstractions.Pagination;
using Asp.Versioning;
using Presentation.Shared;

namespace Presentation.Endpoints;

public interface IEndpoint
{
    RouteHandlerBuilder MapEndpoint(IEndpointRouteBuilder app);
}

public abstract class BooksEndpoint : IEndpoint
{
    public RouteHandlerBuilder MapEndpoint(IEndpointRouteBuilder app)
    {
        var versions = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1.0))
            .ReportApiVersions()
            .Build();

        var group = app
            .MapGroup(ApiConstants.Routes.BooksRoute)
            .WithApiVersionSet(versions)
            .WithTags("Books");

        return MapEndpoint(group);
    }

    protected abstract RouteHandlerBuilder MapEndpoint(RouteGroupBuilder group);
    
    protected static IResult OkResponse<T>(T data)
    {
        var response = ApiResponse<T>.SuccessResponse(data);
        return TypedResults.Ok(response);
    }
    
    protected static IResult OkPagedResponse<T>(PagedCollection<T> data)
    {
        var response = ApiPagedResponse<IReadOnlyCollection<T>>.SuccessResponse(data, data.Pagination);
        return TypedResults.Ok(response);
    }
    
    protected static IResult CreatedResponse<T>(string? routeName, object? routeValues, T data)
    {
        var response = ApiResponse<T>.SuccessResponse(data);
        return TypedResults.CreatedAtRoute(response, routeName, routeValues);
    }
    
    protected static IResult NotFoundResponse()
    {
        var response = ApiResponse.ErrorResponse();
        return TypedResults.NotFound(response);
    }
}