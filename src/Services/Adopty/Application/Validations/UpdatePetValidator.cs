namespace Adopty.Application.Validations;

public class UpdatePetValidator : AbstractValidator<UpdatePet>
{
    public UpdatePetValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Photo).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Age).NotEmpty();
        RuleFor(x => x.Size).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
    }
}