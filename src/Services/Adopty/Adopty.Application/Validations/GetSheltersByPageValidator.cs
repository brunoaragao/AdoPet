namespace Adopty.Application.Validations;

public class GetSheltersByPageValidator : AbstractValidator<GetSheltersByPage>
{
    public GetSheltersByPageValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
    }
}