namespace Adopty.Application.Responses;

public record DeleteShelterResult(
    Guid Id,
    string? Address,
    Guid UserId);