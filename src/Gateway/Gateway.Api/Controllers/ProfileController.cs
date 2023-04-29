namespace Gateway.Api.Controllers;

[Authorize]
[ApiController, Route("Api/V1/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IAdoptyService _adoptyService;

    public ProfileController(IAdoptyService adoptyService)
    {
        _adoptyService = adoptyService;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProfileAsync(UpdateProfileRequest updateProfile)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var photo = updateProfile.Photo;
        var name = updateProfile.Name;
        var phone = updateProfile.Phone;
        var city = updateProfile.City;
        var about = updateProfile.About;

        await _adoptyService.UpdateAdopterByUserIdAsync(userId, photo, name, phone, city, about);
        return NoContent();
    }
}