namespace Adopty.Application.Results;

public record GetAdoptionByIdResult
{
    public required Guid Id { get; init; }
    public required Guid AdopterId { get; init; }
    public required Guid PetId { get; init; }
}