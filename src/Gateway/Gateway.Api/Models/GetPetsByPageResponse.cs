namespace Gateway.Api.Models;

public record GetPetsByPageResponse
{
    public required IEnumerable<GetPetsByPageResponseItem> Items { get; init; }
}