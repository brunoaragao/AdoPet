namespace AdoPet.Services.PetAdoption.Application.Validations;

public class GetAdopterByIdValidator : AbstractValidator<GetAdopterByIdQuery>
{
    public GetAdopterByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}