namespace Adopty.Application.Validations;

public class UpdateAdopterByUserIdValidator : AbstractValidator<UpdateAdopterByUserId>
{
    public UpdateAdopterByUserIdValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}