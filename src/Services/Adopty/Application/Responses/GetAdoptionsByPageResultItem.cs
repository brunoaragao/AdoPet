namespace Adopty.Application.Responses;

public record GetAdoptionsByPageResultItem(
    Guid Id,
    Guid AdopterId,
    Guid PetId);