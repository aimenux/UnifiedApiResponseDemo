using Application.Abstractions.Pagination;
using Domain.Entities;

namespace Application.Abstractions;

public interface IBookRepository
{
    Task<PagedCollection<Book>> GetBooksAsync(int pageIndex, int pageSize, CancellationToken cancellationToken);
    Task<PagedCollection<Book>> SearchBooksAsync(string searchTerm, int pageIndex, int pageSize, CancellationToken cancellationToken);
    Task<Book?> GetBookByIdAsync(string id, CancellationToken cancellationToken);
    Task InsertBookAsync(Book book, CancellationToken cancellationToken);
    Task<int> UpdateBookAsync(Book book, CancellationToken cancellationToken);
    Task<int> DeleteBookAsync(string id, CancellationToken cancellationToken);
}