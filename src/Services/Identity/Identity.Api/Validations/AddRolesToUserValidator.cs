namespace Identity.Api.Validations;

public class AddRolesToUserValidator : AbstractValidator<AddRolesToUser>
{
    public AddRolesToUserValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Roles)
            .NotEmpty()
            .ForEach(role => role.NotEmpty());
    }
}