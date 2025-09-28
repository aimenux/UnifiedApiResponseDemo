namespace Application.Abstractions.Pagination;

public class PagedCollection<T> : List<T>
{
    public PagedCollection()
    {
    }

    public PagedCollection(IEnumerable<T> collection, Paging pagination) : base(collection)
    {
        Pagination = pagination;
    }
    
    public Paging Pagination { get; private init; } = new();
}