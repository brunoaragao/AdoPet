namespace AdoPet.Services.PetAdoption.Application.Validations;

public class DeleteAdopterValidator : AbstractValidator<DeleteAdopterCommand>
{
    public DeleteAdopterValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}