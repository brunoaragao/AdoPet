namespace Adopty.Application.Requests;

public record CreateAdopter(
    Guid UserId,
    string? Photo = null,
    string? Name = null,
    string? Phone = null,
    string? City = null,
    string? About = null);