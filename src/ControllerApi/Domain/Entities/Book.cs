namespace Domain.Entities;

public sealed record Book
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Author { get; init; }
}