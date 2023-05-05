namespace Adopty.Application.Requests;

public record GetPetsByPage(
    int PageNumber,
    int PageSize);