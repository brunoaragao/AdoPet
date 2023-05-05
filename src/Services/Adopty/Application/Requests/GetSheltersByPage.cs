namespace Adopty.Application.Requests;

public record GetSheltersByPage(
    int PageNumber,
    int PageSize);