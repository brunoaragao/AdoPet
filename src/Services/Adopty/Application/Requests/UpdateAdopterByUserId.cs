namespace Adopty.Application.Requests;

public record UpdateAdopterByUserId(
    Guid UserId,
    string? Photo = null,
    string? Name = null,
    string? Phone = null,
    string? City = null,
    string? About = null);