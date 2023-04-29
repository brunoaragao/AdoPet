namespace Adopty.Domain.Contracts;

public record GetSheltersByPage
{
    public required int Page { get; init; }
    public required int Size { get; init; }
}