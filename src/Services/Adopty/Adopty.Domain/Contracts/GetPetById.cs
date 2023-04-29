namespace Adopty.Domain.Contracts;

public record GetPetById
{
    public required Guid Id { get; init; }
}