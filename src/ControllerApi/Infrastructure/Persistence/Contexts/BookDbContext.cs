using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public sealed class BookDbContext : DbContext
{
    private static readonly Assembly CurrentAssembly = typeof(DependencyInjection).Assembly;
    
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(CurrentAssembly);
    }
}