namespace Adopty.Domain.Contracts;

public record DeleteShelter
{
    public required Guid Id { get; init; }
}