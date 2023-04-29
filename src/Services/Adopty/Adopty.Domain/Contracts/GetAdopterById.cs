namespace Adopty.Domain.Contracts;

public record GetAdopterById
{
    public required Guid Id { get; init; }
}