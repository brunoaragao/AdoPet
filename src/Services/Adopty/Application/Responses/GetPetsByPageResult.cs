namespace Adopty.Application.Responses;

public record GetPetsByPageResult(IEnumerable<GetPetsByPageResultItem> Items);