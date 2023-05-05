namespace Adopty.Application.Responses;

public record DeleteAdoptionResult(
    Guid Id,
    Guid AdopterId,
    Guid PetId);