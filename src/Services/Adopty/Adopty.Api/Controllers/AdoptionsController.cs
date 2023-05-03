namespace Adopty.Api.Controllers;

[ApiController]
[Route("Api/V1/[controller]")]
public class AdoptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdoptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAdoptionsByPage(int page = 1, int size = 10)
    {
        var request = new GetAdoptionsByPage { Page = page, Size = size };
        var client = _mediator.CreateRequestClient<GetAdoptionsByPage>();
        var response = await client.GetResponse<GetAdoptionsByPageResult>(request);
        return Ok(response.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdoptionById(Guid id)
    {
        var request = new GetAdoptionById { Id = id };
        var client = _mediator.CreateRequestClient<GetAdoptionById>();
        var response = await client.GetResponse<GetAdoptionByIdResult>(request);
        return Ok(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdoption(CreateAdoption request)
    {
        var client = _mediator.CreateRequestClient<CreateAdoption>();
        var response = await client.GetResponse<CreateAdoptionResult>(request);
        return CreatedAtAction(nameof(GetAdoptionById), new { id = response.Message.Id }, response.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAdoption(UpdateAdoption message)
    {
        var client = _mediator.CreateRequestClient<UpdateAdoption>();
        var response = await client.GetResponse<UpdateAdoptionResult>(message);
        return Ok(response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdoption(Guid id)
    {
        var request = new DeleteAdoption { Id = id };
        var client = _mediator.CreateRequestClient<DeleteAdoption>();
        var response = await client.GetResponse<DeleteAdoptionResult>(request);
        return Ok(response.Message);
    }
}