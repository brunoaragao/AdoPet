namespace Adopty.Presentation.Controllers;

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
    public async Task<IActionResult> GetAdoptionsByPage(
        int pageNumber = 1,
        int pageSize = 10)
    {
        return Ok(
            await _mediator
                .CreateRequestClient<GetAdoptionsByPage>()
                .GetResponse<GetAdoptionsByPageResult>(
                    new GetAdoptionsByPage(
                        pageNumber,
                        pageSize)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdoptionById(Guid id)
    {
        return Ok(
            await _mediator
                .CreateRequestClient<GetAdoptionById>()
                .GetResponse<GetAdoptionByIdResult>(
                    new GetAdoptionById(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdoption(CreateAdoption request)
    {
        var response = await _mediator
            .CreateRequestClient<CreateAdoption>()
            .GetResponse<CreateAdoptionResult>(request);

        var result = response.Message;
        return CreatedAtAction(
            nameof(GetAdoptionById),
            new { id = result.Id },
            result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdoption(Guid id)
    {
        var response = await _mediator
            .CreateRequestClient<DeleteAdoption>()
            .GetResponse<DeleteAdoptionResult>(
                new DeleteAdoption(id));

        return Ok(response.Message);
    }
}