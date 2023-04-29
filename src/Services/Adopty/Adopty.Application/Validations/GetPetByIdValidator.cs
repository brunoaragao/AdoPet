namespace Adopty.Application.Validations;

public class GetPetByIdValidator : AbstractValidator<GetPetById>
{
    public GetPetByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}