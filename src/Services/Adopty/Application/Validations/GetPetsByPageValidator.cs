namespace Adopty.Application.Validations;

public class GetPetsByPageValidator : AbstractValidator<GetPetsByPage>
{
    public GetPetsByPageValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}