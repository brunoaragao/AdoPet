namespace Adopty.Application.Validations;

public class GetShelterByIdValidator : AbstractValidator<GetShelterById>
{
    public GetShelterByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}