namespace Identity.Api.Consumers;

public class AddRolesToUserConsumer : IConsumer<AddRolesToUser>
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;

    public AddRolesToUserConsumer(UserManager<IdentityUser<Guid>> userManager)
    {
        _userManager = userManager;
    }

    public async Task Consume(ConsumeContext<AddRolesToUser> context)
    {
        var message = context.Message;
        var user = await _userManager.FindByNameAsync(message.UserName);
        if (user is null)
        {
            throw new InvalidOperationException("User not found");
        }
        var result = await _userManager.AddToRolesAsync(user, message.Roles);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Failed to add roles to user");
        }
    }
}