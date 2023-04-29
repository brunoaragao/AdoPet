namespace Adopty.Domain.Contracts;

public record GetAdoptionById
{
    public required Guid Id { get; init; }
}