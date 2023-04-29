namespace Identity.Api.Controllers;

[Route("connect")]
[ApiController]
public class ConnectController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IBus _bus;

    public ConnectController(IMediator mediator, IBus bus)
    {
        _mediator = mediator;
        _bus = bus;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest message)
    {
        var userName = message.UserName;
        var email = message.Email;
        var password = message.Password;
        var roles = message.Roles;

        var claims = GetClaims(message);
        await RegisterUserAsync(userName, email, password);
        await AddRolesToUserAsync(userName, roles);
        await AddClaimsToUserAsync(userName, claims);

        var user = await GetUserByNameAsync(userName);
        await PublishAccountRegisteredEventAsync(user.Id, userName, email, roles, claims);

        return Ok();
    }

    private async Task RegisterUserAsync(string userName, string email, string password)
    {
        await _mediator.Send(new RegisterUser
        {
            UserName = userName,
            Email = email,
            Password = password
        });
    }

    private async Task PublishAccountRegisteredEventAsync(Guid userId, string userName, string email, IEnumerable<string> roles, IEnumerable<Claim> claims)
    {
        await _bus.Publish(new AccountRegistered
        {
            UserId = userId,
            UserName = userName,
            Email = email,
            Roles = roles,
            Claims = claims.Select(x => new KeyValuePair<string, string>(x.Type, x.Value))
        });
    }

    private async Task AddClaimsToUserAsync(string userName, IEnumerable<Claim> claims)
    {
        await _mediator.Send(new AddClaimsToUser
        {
            UserName = userName,
            Claims = claims
        });
    }

    private async Task AddRolesToUserAsync(string userName, IEnumerable<string> roles)
    {
        await _mediator.Send(new AddRolesToUser
        {
            UserName = userName,
            Roles = roles
        });
    }

    private async Task<GetUserByNameResult> GetUserByNameAsync(string userName)
    {
        var client = _mediator.CreateRequestClient<GetUserByName>();

        var response = await client.GetResponse<GetUserByNameResult>(new GetUserByName
        {
            UserName = userName
        });
        return response.Message;
    }

    private static IEnumerable<Claim> GetClaims(RegisterRequest message)
    {
        var claims = new List<Claim>();

        if (!string.IsNullOrWhiteSpace(message.FullName))
        {
            claims.Add(new Claim("FullName", message.FullName));
        }

        return claims;
    }
}