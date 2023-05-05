namespace Adopty.Application.Validations;

public class GetSheltersByPageValidator : AbstractValidator<GetSheltersByPage>
{
    public GetSheltersByPageValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}