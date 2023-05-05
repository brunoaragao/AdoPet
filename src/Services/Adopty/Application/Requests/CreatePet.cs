namespace Adopty.Application.Requests;

public record CreatePet(
    string Photo,
    string Name,
    string Age,
    string Size,
    string Description,
    Guid ShelterId);