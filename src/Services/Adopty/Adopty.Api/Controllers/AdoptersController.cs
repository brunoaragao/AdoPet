namespace Adopty.Api.Controllers;

[ApiController]
[Route("Api/V1/[controller]")]
public class AdoptersController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdoptersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAdoptersByPage(int page = 1, int size = 10)
    {
        var request = new GetAdoptersByPage { Page = page, Size = size };
        var client = _mediator.CreateRequestClient<GetAdoptersByPage>();
        var response = await client.GetResponse<GetAdoptersByPageResult>(request);
        return Ok(response.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdopterById(Guid id)
    {
        var request = new GetAdopterById { Id = id };
        var client = _mediator.CreateRequestClient<GetAdopterById>();
        var response = await client.GetResponse<GetAdopterByIdResult>(request);
        return Ok(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdopter(CreateAdopter request)
    {
        var client = _mediator.CreateRequestClient<CreateAdopter>();
        var response = await client.GetResponse<CreateAdopterResult>(request);
        return CreatedAtAction(nameof(GetAdopterById), new { id = response.Message.Id }, response.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAdopter(UpdateAdopter message)
    {
        var client = _mediator.CreateRequestClient<UpdateAdopter>();
        var response = await client.GetResponse<UpdateAdopterResult>(message);
        return Ok(response.Message);
    }

    [HttpPost("UpdateAdopterByUserId")]
    public async Task<IActionResult> UpdateAdopterByUserIdAsync(UpdateAdopterByUserId message)
    {
        var client = _mediator.CreateRequestClient<UpdateAdopterByUserId>();
        var response = await client.GetResponse<UpdateAdopterByUserIdResult>(message);
        return Ok(response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdopter(Guid id)
    {
        var request = new DeleteAdopter { Id = id };
        var client = _mediator.CreateRequestClient<DeleteAdopter>();
        var response = await client.GetResponse<DeleteAdopterResult>(request);
        return Ok(response.Message);
    }
}