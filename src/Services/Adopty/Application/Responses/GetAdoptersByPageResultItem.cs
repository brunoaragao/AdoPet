namespace Adopty.Application.Responses;

public record GetAdoptersByPageResultItem(
    Guid Id,
    string? Photo,
    string? Name,
    string? Phone,
    string? City,
    string? About,
    Guid UserId);