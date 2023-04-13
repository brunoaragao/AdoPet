namespace AdoPet.Services.PetAdoption.Application.Validations;

public class CreateAdopterValidator : AbstractValidator<CreateAdopterCommand>
{
    public CreateAdopterValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Phone).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Photo).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}