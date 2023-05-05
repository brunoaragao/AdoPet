namespace Adopty.Application.Responses;

public record CreateShelterResult(
    Guid Id,
    string? Address,
    Guid UserId);