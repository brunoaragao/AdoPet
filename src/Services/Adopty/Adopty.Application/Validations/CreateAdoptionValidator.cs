namespace Adopty.Application.Validations;

public class CreateAdoptionValidator : AbstractValidator<CreateAdoption>
{
    public CreateAdoptionValidator()
    {
        RuleFor(x => x.AdopterId).NotEmpty();
        RuleFor(x => x.PetId).NotEmpty();
    }
}