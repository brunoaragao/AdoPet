namespace Adopty.Application.Responses;

public record GetSheltersByPageResult(IEnumerable<GetSheltersByPageResultItem> Items);