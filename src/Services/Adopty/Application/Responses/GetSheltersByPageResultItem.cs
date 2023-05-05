namespace Adopty.Application.Responses;

public record GetSheltersByPageResultItem(
    Guid Id,
    string? Address,
    Guid UserId);