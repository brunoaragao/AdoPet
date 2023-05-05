namespace Adopty.Application.Requests;

public record UpdatePet(
    Guid Id,
    string Photo,
    string Name,
    string Age,
    string Size,
    string Description,
    string Address);