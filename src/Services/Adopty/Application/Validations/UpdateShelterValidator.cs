namespace Adopty.Application.Validations;

public class UpdateShelterValidator : AbstractValidator<UpdateShelter>
{
    public UpdateShelterValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}