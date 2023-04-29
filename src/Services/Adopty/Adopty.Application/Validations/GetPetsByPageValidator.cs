namespace Adopty.Application.Validations;

public class GetPetsByPageValidator : AbstractValidator<GetPetsByPage>
{
    public GetPetsByPageValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
    }
}