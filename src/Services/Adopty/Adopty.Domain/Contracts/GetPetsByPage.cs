namespace Adopty.Domain.Contracts;

public record GetPetsByPage
{
    public required int Page { get; init; }
    public required int Size { get; init; }
}