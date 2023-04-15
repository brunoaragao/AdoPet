namespace AdoPet.Services.PetAdoption.Application.Validations;

public class CreatePetValidator : AbstractValidator<CreatePetCommand>
{
    public CreatePetValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Age).NotEmpty();
        RuleFor(x => x.Size).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Photo).NotEmpty();
        RuleFor(x => x.ShelterId).NotEmpty();
    }
}