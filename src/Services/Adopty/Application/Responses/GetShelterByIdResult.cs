namespace Adopty.Application.Responses;

public record GetShelterByIdResult(
    Guid Id,
    string? Address,
    Guid UserId);