namespace Adopty.Application.Responses;

public record UpdateAdopterResult(
    Guid Id,
    string? Photo,
    string? Name,
    string? Phone,
    string? City,
    string? About,
    Guid UserId);