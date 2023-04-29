namespace Adopty.Infrastructure.Messaging.Consumers;

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

        if (roles.Contains("Adopter"))
        {
            var claims = message.Claims;
            var fullName = claims.Single(x => x.Key is "FullName").Value;
            var createAdopter = new CreateAdopter
            {
                Photo = null,
                Name = fullName,
                Phone = null,
                City = null,
                About = null,
                UserId = userId
            };
            await _mediator.Send(createAdopter);
        }

        if (roles.Contains("Shelter"))
        {
            var createShelter = new CreateShelter
            {
                Address = null,
                UserId = userId
            };
            await _mediator.Send(createShelter);
        }
    }
}