namespace Adopty.Application.Responses;

public record GetPetsByPageResultItem(
    Guid Id,
    string Photo,
    string Name,
    string Age,
    string Size,
    string Description,
    Guid ShelterId,
    string? ShelterAddress);