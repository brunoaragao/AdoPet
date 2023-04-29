namespace Adopty.Application.Results;

public record GetSheltersByPageResultItem
{
    public required Guid Id { get; init; }
    public required string? Address { get; init; }
    public required Guid UserId { get; init; }
}