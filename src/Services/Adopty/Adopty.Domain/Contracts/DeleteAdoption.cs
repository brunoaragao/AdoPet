namespace Adopty.Domain.Contracts;

public record DeleteAdoption
{
    public required Guid Id { get; init; }
}