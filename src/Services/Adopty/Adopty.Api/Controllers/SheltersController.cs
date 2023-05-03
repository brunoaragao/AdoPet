namespace Adopty.Api.Controllers;

[ApiController]
[Route("Api/V1/[controller]")]
public class SheltersController : ControllerBase
{
    private readonly IMediator _mediator;

    public SheltersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetSheltersByPage(int page = 1, int size = 10)
    {
        var request = new GetSheltersByPage { Page = page, Size = size };
        var client = _mediator.CreateRequestClient<GetSheltersByPage>();
        var response = await client.GetResponse<GetSheltersByPageResult>(request);
        return Ok(response.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShelterById(Guid id)
    {
        var request = new GetShelterById { Id = id };
        var client = _mediator.CreateRequestClient<GetShelterById>();
        var response = await client.GetResponse<GetShelterByIdResult>(request);
        return Ok(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShelter(CreateShelter request)
    {
        var client = _mediator.CreateRequestClient<CreateShelter>();
        var response = await client.GetResponse<CreateShelterResult>(request);
        return CreatedAtAction(nameof(GetShelterById), new { id = response.Message.Id }, response.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateShelter(UpdateShelter message)
    {
        var client = _mediator.CreateRequestClient<UpdateShelter>();
        var response = await client.GetResponse<UpdateShelterResult>(message);
        return Ok(response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShelter(Guid id)
    {
        var request = new DeleteShelter { Id = id };
        var client = _mediator.CreateRequestClient<DeleteShelter>();
        var response = await client.GetResponse<DeleteShelterResult>(request);
        return Ok(response.Message);
    }
}