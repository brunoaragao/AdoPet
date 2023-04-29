namespace Adopty.Domain.Contracts;

public record UpdatePet
{
    public required Guid Id { get; init; }
    public required string Photo { get; init; }
    public required string Name { get; init; }
    public required string Age { get; init; }
    public required string Size { get; init; }
    public required string Description { get; init; }
    public required string Address { get; init; }
    public required Guid ShelterId { get; init; }
}