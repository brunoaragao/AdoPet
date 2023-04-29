namespace Adopty.Domain.Contracts;

public record CreateShelter
{
    public required string? Address { get; init; }
    public required Guid UserId { get; init; }
}