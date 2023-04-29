namespace Adopty.Application.Validations;

public class GetAdoptionByIdValidator : AbstractValidator<GetAdoptionById>
{
    public GetAdoptionByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}