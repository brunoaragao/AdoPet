namespace Adopty.Domain.Contracts;

public record GetAdoptionsByPage
{
    public required int Page { get; init; }
    public required int Size { get; init; }
}