using System.Linq.Expressions;
using Application.Abstractions;
using Application.Abstractions.Pagination;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class BookRepository : IBookRepository
{
    private readonly BookDbContext _context;

    public BookRepository(BookDbContext context)
    {
        _context = context;
    }
    
    public Task<PagedCollection<Book>> GetBooksAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var query = _context.Set<Book>().AsQueryable();
        
        return GetPagedBooksAsync(query, pageIndex, pageSize, cancellationToken);
    }

    public Task<PagedCollection<Book>> SearchBooksAsync(string searchTerm, int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        Expression<Func<Book, bool>> filter = x => x.Title.Contains(searchTerm) || x.Author.Contains(searchTerm);
        
        var query = _context.Set<Book>().AsQueryable().Where(filter);
        
        return GetPagedBooksAsync(query, pageIndex, pageSize, cancellationToken);
    }

    public async Task<Book?> GetBookByIdAsync(string id, CancellationToken cancellationToken)
    {
        var book = await _context.Set<Book>().FindAsync([id], cancellationToken);
        return book;
    }

    public async Task InsertBookAsync(Book book, CancellationToken cancellationToken)
    {
        await _context.Set<Book>().AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateBookAsync(Book book, CancellationToken cancellationToken)
    {
        _context.Entry(book).State = EntityState.Modified;
        var rows = await _context.SaveChangesAsync(cancellationToken);
        return rows;
    }

    public async Task<int> DeleteBookAsync(string id, CancellationToken cancellationToken)
    {
        var book = await GetBookByIdAsync(id, cancellationToken);
        if (book is null) return 0;
        _context.Set<Book>().Remove(book);
        return await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task<PagedCollection<Book>> GetPagedBooksAsync(IQueryable<Book> query, int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await query.CountAsync(cancellationToken);
        
        if (totalCount == 0)
        {
            return new PagedCollection<Book>([], new Paging(pageIndex, pageSize, totalCount));
        }
        
        var books = await query
            .Take(pageSize)
            .Skip((pageIndex - 1) * pageSize)
            .OrderBy(x => x.Id)
            .ToListAsync(cancellationToken);

        var pagination = new Paging(pageIndex, pageSize, totalCount);

        return new PagedCollection<Book>(books, pagination);
    }
}