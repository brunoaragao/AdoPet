namespace Adopty.Domain.Contracts;

public record DeletePet
{
    public required Guid Id { get; init; }
}