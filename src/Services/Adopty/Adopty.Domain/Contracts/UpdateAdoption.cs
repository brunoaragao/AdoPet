namespace Adopty.Domain.Contracts;

public record UpdateAdoption
{
    public required Guid Id { get; init; }
    public required Guid AdopterId { get; init; }
    public required Guid PetId { get; init; }
}