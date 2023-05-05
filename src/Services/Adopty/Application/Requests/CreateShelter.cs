namespace Adopty.Application.Requests;

public record CreateShelter(
    Guid UserId,
    string? Address = null);