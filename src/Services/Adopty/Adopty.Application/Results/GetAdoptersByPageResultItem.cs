namespace Adopty.Application.Results;

public record GetAdoptersByPageResultItem
{
    public required Guid Id { get; init; }
    public required string? Photo { get; init; }
    public required string? Name { get; init; }
    public required string? Phone { get; init; }
    public required string? City { get; init; }
    public required string? About { get; init; }
    public required Guid UserId { get; init; }
}