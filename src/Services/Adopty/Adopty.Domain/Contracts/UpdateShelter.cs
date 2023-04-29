namespace Adopty.Domain.Contracts;

public record UpdateShelter
{
    public required Guid Id { get; init; }
    public required string? Address { get; init; }
    public required Guid UserId { get; init; }
}