namespace Adopty.Domain.Contracts;

public record DeleteAdopter
{
    public required Guid Id { get; init; }
}