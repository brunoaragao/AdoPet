namespace Adopty.Application.Handlers;

public class AccountRegisteredConsumer : IConsumer<AccountRegistered>
{
    private readonly IMediator _mediator;

    public AccountRegisteredConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<AccountRegistered> context)
    {
        var message = context.Message;
        var userId = message.UserId;
        var roles = message.Roles;

        // TODO: use a design pattern here to avoid if/else, maybe a factory
        if (roles.Contains("Adopter"))
        {
            await _mediator.Send(
                new CreateAdopter(
                    userId,
                    Name: message.Claims.Single(
                        c => c.Key is "FullName").Value));
        }

        if (roles.Contains("Shelter"))
        {
            await _mediator.Send(
                new CreateShelter(
                    userId));
        }
    }
}