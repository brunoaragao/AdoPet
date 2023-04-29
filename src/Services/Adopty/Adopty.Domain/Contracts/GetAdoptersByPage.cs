namespace Adopty.Domain.Contracts;

public record GetAdoptersByPage
{
    public required int Page { get; init; }
    public required int Size { get; init; }
}