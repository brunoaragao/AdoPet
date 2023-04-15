namespace AdoPet.Services.PetAdoption.Application.Validations;

public class CreateAdoptionValidator : AbstractValidator<CreateAdoptionCommand>
{
    public CreateAdoptionValidator()
    {
        RuleFor(x => x.AdopterId).NotEmpty();
        RuleFor(x => x.PetId).NotEmpty();
    }
}