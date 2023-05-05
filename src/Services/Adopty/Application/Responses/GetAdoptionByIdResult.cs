namespace Adopty.Application.Responses;

public record GetAdoptionByIdResult(
    Guid Id,
    Guid AdopterId,
    Guid PetId);