namespace Gateway.Api.Controllers;

[ApiController, Route("Api/V1/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public AccountController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var username = request.Email;
        var email = request.Email;
        var password = request.Password;
        var roles = new[] { "User", "Adopter" };
        string? fullName = request.FullName;
        await _identityService.RegisterUserAsync(username, email, password, roles, fullName);
        return NoContent();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var username = request.Username;
        var password = request.Password;
        var token = await _identityService.LoginAsync(username, password);
        return Ok(token);
    }
}