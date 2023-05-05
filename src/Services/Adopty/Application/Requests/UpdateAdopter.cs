namespace Adopty.Application.Requests;

public record UpdateAdopter(
    Guid Id,
    string? Photo = null,
    string? Name = null,
    string? Phone = null,
    string? City = null,
    string? About = null);