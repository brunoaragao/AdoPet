namespace Adopty.Presentation.Controllers;

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
    public async Task<IActionResult> GetPetsByPage(int pageNumber = 1, int pageSize = 10)
    {
        var response = await _mediator
            .CreateRequestClient<GetPetsByPage>()
            .GetResponse<GetPetsByPageResult>(
                new GetPetsByPage(
                    pageNumber,
                    pageSize));

        return Ok(response.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPetById(Guid id)
    {
        var response = await _mediator
            .CreateRequestClient<GetPetById>()
            .GetResponse<GetPetByIdResult>(
                new GetPetById(id));

        return Ok(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePet(CreatePet request)
    {
        var response = await _mediator
            .CreateRequestClient<CreatePet>()
            .GetResponse<CreatePetResult>(request);

        var result = response.Message;
        return CreatedAtAction(
            nameof(GetPetById),
            new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePet(UpdatePet message)
    {
        var response = await _mediator
            .CreateRequestClient<UpdatePet>()
            .GetResponse<UpdatePetResult>(message);

        return Ok(response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(Guid id)
    {
        var response = await _mediator
            .CreateRequestClient<DeletePet>()
            .GetResponse<DeletePetResult>(
                new DeletePet(id));

        return Ok(response.Message);
    }
}