namespace Gateway.Api.Models;

public record GetPetsByPageResponseItem
{
    public Guid Id { get; init; }
    public string? Photo { get; init; }
    public string? Name { get; init; }
    public string? Age { get; init; }
    public string? Size { get; init; }
    public string? Description { get; init; }
    public string? ShelterAddress { get; init; }
}