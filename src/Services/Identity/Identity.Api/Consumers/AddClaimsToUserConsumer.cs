namespace Identity.Api.Consumers;

public class AddClaimsToUserConsumer : IConsumer<AddClaimsToUser>
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;

    public AddClaimsToUserConsumer(UserManager<IdentityUser<Guid>> userManager)
    {
        _userManager = userManager;
    }

    public async Task Consume(ConsumeContext<AddClaimsToUser> context)
    {
        var message = context.Message;
        var user = await _userManager.FindByNameAsync(message.UserName);
        if (user is null)
        {
            throw new InvalidOperationException("User not found");
        }
        var result = await _userManager.AddClaimsAsync(user, message.Claims);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Failed to add claims to user");
        }
    }
}