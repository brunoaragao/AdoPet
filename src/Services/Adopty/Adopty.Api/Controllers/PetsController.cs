namespace Adopty.Api.Controllers;

[ApiController]
[Route("Api/V1/[controller]")]
public class PetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPetsByPage(int page = 1, int size = 10)
    {
        var request = new GetPetsByPage { Page = page, Size = size };
        var client = _mediator.CreateRequestClient<GetPetsByPage>();
        var response = await client.GetResponse<GetPetsByPageResult>(request);
        return Ok(response.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPetById(Guid id)
    {
        var request = new GetPetById { Id = id };
        var client = _mediator.CreateRequestClient<GetPetById>();
        var response = await client.GetResponse<GetPetByIdResult>(request);
        return Ok(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePet(CreatePet request)
    {
        var client = _mediator.CreateRequestClient<CreatePet>();
        var response = await client.GetResponse<CreatePetResult>(request);
        return CreatedAtAction(nameof(GetPetById), new { id = response.Message.Id }, response.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePet(UpdatePet message)
    {
        var client = _mediator.CreateRequestClient<UpdatePet>();
        var response = await client.GetResponse<UpdatePetResult>(message);
        return Ok(response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(Guid id)
    {
        var request = new DeletePet { Id = id };
        var client = _mediator.CreateRequestClient<DeletePet>();
        var response = await client.GetResponse<DeletePetResult>(request);
        return Ok(response.Message);
    }
}