namespace Adopty.Application.Requests;

public record UpdateShelter(
    Guid Id,
    string? Address = null);