using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .ToTable("Books");
        
        builder
            .HasKey(e => e.Id);
        
        builder
            .Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(e => e.Author)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .HasData(new List<Book>
            {
                Generate(id: "1"),
                Generate(id: "2")
            });
    }
    
    private static Book Generate(string id) => new ()
    {
        Id = id,
        Title = $"title-{id}",
        Author = $"author-{id}"
    };
}