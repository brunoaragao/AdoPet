namespace Adopty.Presentation.Controllers;

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
    public async Task<IActionResult> GetSheltersByPage(
        int pageNumber = 1,
        int pageSize = 10)
    {
        var response = await _mediator
            .CreateRequestClient<GetSheltersByPage>()
            .GetResponse<GetSheltersByPageResult>(
                new GetSheltersByPage(
                    pageNumber,
                    pageSize));

        return Ok(response.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShelterById(Guid id)
    {
        var response = await _mediator
            .CreateRequestClient<GetShelterById>()
            .GetResponse<GetShelterByIdResult>(
                new GetShelterById(id));

        return Ok(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShelter(CreateShelter request)
    {
        var response = await _mediator
            .CreateRequestClient<CreateShelter>()
            .GetResponse<CreateShelterResult>(request);

        var result = response.Message;
        return CreatedAtAction(
            nameof(GetShelterById),
            new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateShelter(UpdateShelter message)
    {
        var response = await _mediator
            .CreateRequestClient<UpdateShelter>()
            .GetResponse<UpdateShelterResult>(message);

        return Ok(response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShelter(Guid id)
    {
        var response = await _mediator
            .CreateRequestClient<DeleteShelter>()
            .GetResponse<DeleteShelterResult>(
                new DeleteShelter(id));

        return Ok(response.Message);
    }
}