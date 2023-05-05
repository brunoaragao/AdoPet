namespace Adopty.Application.Responses;

public record UpdateShelterResult(
    Guid Id,
    string? Address,
    Guid UserId);