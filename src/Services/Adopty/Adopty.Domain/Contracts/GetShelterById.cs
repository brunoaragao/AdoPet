namespace Adopty.Domain.Contracts;

public record GetShelterById
{
    public required Guid Id { get; init; }
}