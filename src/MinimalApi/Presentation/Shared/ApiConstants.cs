namespace Presentation.Shared;

public static class ApiConstants
{
    public static class Routes
    {
        public const string BooksRoute = "api/v{version:apiVersion}/books";
    }
    
    public static class Versions
    {
        public const string V1 = "1.0";
    }

    public static class Pagination
    {
        public const int DefaultPageIndex = 1;
        public const int DefaultPageSize = 10;
    }
}