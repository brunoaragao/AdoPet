namespace Identity.Api.Consumers;

public class GetUserByNameConsumer : IConsumer<GetUserByName>
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;

    public GetUserByNameConsumer(UserManager<IdentityUser<Guid>> userManager)
    {
        _userManager = userManager;
    }

    public async Task Consume(ConsumeContext<GetUserByName> context)
    {
        var message = context.Message;
        var user = await _userManager.FindByNameAsync(message.UserName);
        if (user is null)
        {
            throw new InvalidOperationException("User not found");
        }

        await context.RespondAsync(new GetUserByNameResult
        {
            Id = user.Id,
            UserName = user.UserName!,
            Email = user.Email!
        });
    }
}