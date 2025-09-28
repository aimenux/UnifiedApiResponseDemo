using Application.Abstractions.Pagination;

namespace Presentation.Shared;

public class ApiPagedResponse<T> : ApiResponse<T>
{
    public required Paging Paging { get; init; }
    
    public static ApiPagedResponse<T> SuccessResponse(T data, Paging paging)
    {
        return new ApiPagedResponse<T>
        {
            Success = true,
            Data = data,
            Paging = paging
        };
    }
    
    public static ApiPagedResponse<T> ErrorResponse(List<string>? errors, Paging paging)
    {
        return new ApiPagedResponse<T>
        {
            Success = false,
            Errors = errors,
            Paging = paging
        };
    }
}