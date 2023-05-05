namespace Adopty.Application.Responses;

public record CreateAdoptionResult(
    Guid Id,
    Guid AdopterId,
    Guid PetId);