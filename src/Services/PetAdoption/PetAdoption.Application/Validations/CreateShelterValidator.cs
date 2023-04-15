namespace AdoPet.Services.PetAdoption.Application.Validations;

public class CreateShelterValidator : AbstractValidator<CreateShelterCommand>
{
    public CreateShelterValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
    }
}