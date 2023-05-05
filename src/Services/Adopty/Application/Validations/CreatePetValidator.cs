namespace Adopty.Application.Validations;

public class CreatePetValidator : AbstractValidator<CreatePet>
{
    public CreatePetValidator()
    {
        RuleFor(x => x.Photo).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Age).NotEmpty();
        RuleFor(x => x.Size).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.ShelterId).NotEmpty();
    }
}