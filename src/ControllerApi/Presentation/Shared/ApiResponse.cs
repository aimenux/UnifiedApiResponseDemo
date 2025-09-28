namespace Presentation.Shared;

public class ApiResponse
{
    public bool Success { get; init; }
    public List<string>? Errors { get; init; }
    
    public static ApiResponse SuccessResponse()
    {
        return new ApiResponse
        {
            Success = true
        };
    }
    
    public static ApiResponse ErrorResponse(List<string>? errors = null)
    {
        return new ApiResponse
        {
            Success = false,
            Errors = errors
        };
    }
}

public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; init; }
    
    public static ApiResponse<T> SuccessResponse(T data)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data
        };
    }
    
    public new static ApiResponse<T> ErrorResponse(List<string>? errors = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Errors = errors
        };
    }
}