namespace Identity.Api.Consumers;

public class RegisterUserConsumer : IConsumer<RegisterUser>
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;

    public RegisterUserConsumer(UserManager<IdentityUser<Guid>> userManager)
    {
        _userManager = userManager;
    }

    public async Task Consume(ConsumeContext<RegisterUser> context)
    {
        var message = context.Message;
        var user = new IdentityUser<Guid>
        {
            UserName = message.UserName,
            Email = message.Email
        };
        var result = await _userManager.CreateAsync(user, context.Message.Password);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Failed to create user");
        }
    }
}