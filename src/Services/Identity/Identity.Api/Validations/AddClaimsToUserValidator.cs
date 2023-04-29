namespace Identity.Api.Validations;

public class AddClaimsToUserValidator : AbstractValidator<AddClaimsToUser>
{
    public AddClaimsToUserValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Claims)
            .NotEmpty()
            .ForEach(claim => claim.NotEmpty());
    }
}