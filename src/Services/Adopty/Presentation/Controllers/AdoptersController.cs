namespace Adopty.Presentation.Controllers;

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
    public async Task<IActionResult> GetAdoptersByPage(
        int pageNumber = 1,
        int pageSize = 10)
    {
        var response = await _mediator
            .CreateRequestClient<GetAdoptersByPage>()
            .GetResponse<GetAdoptersByPageResult>(
                new GetAdoptersByPage(
                    pageNumber,
                    pageSize));

        return Ok(response.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdopterById(Guid id)
    {
        var response = await _mediator
            .CreateRequestClient<GetAdopterById>()
            .GetResponse<GetAdopterByIdResult>(
                new GetAdopterById(id));

        return Ok(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdopter(CreateAdopter request)
    {
        var response = await _mediator
            .CreateRequestClient<CreateAdopter>()
            .GetResponse<CreateAdopterResult>(request);

        var result = response.Message;
        return CreatedAtAction(
            nameof(GetAdopterById),
            new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAdopter(UpdateAdopter message)
    {
        var response = await _mediator
            .CreateRequestClient<UpdateAdopter>()
            .GetResponse<UpdateAdopterResult>(message);

        return Ok(response.Message);
    }

    [HttpPost("UpdateAdopterByUserId")]
    public async Task<IActionResult> UpdateAdopterByUserIdAsync(UpdateAdopterByUserId message)
    {
        var response = await _mediator
            .CreateRequestClient<UpdateAdopterByUserId>()
            .GetResponse<UpdateAdopterByUserIdResult>(message);

        return Ok(response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdopter(Guid id)
    {
        var response = await _mediator
            .CreateRequestClient<DeleteAdopter>()
            .GetResponse<DeleteAdopterResult>(
                new DeleteAdopter(id));

        return Ok(response.Message);
    }
}