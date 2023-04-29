namespace Adopty.Application.Results;

public record DeleteAdoptionResult
{
    public required Guid Id { get; init; }
    public required Guid AdopterId { get; init; }
    public required Guid PetId { get; init; }
}