namespace Gateway.Api.Controllers;

[Authorize]
[ApiController, Route("Api/V1/[controller]")]
public class PetsController : ControllerBase
{
    private readonly IAdoptyService _adoptyService;

    public PetsController(IAdoptyService adoptyService)
    {
        _adoptyService = adoptyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPetsByPageAsync(int page = 1)
    {
        var pets = await _adoptyService.GetPetsByPageAsync(page);
        return Ok(pets);
    }
}