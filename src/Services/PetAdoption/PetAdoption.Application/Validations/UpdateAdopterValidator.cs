namespace AdoPet.Services.PetAdoption.Application.Validations;

public class UpdateAdopterValidator : AbstractValidator<UpdateAdopterCommand>
{
    public UpdateAdopterValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Phone).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Photo).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}