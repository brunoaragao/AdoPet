namespace Adopty.Domain.Contracts;

public record CreateAdoption
{
    public required Guid AdopterId { get; init; }
    public required Guid PetId { get; init; }
}