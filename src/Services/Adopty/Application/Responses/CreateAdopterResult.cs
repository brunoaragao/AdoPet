namespace Adopty.Application.Responses;

public record CreateAdopterResult(
    Guid Id,
    Guid UserId,
    string? Photo,
    string? Name,
    string? Phone,
    string? City,
    string? About);