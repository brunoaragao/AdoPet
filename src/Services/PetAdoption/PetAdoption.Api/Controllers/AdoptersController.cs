using static Microsoft.AspNetCore.Http.StatusCodes;

namespace AdoPet.Services.PetAdoption.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AdoptersController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdoptersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(Status200OK, Type = typeof(AdopterDto[]))]
    public async Task<IActionResult> GetAdoptersAsync()
    {
        var query = new GetAdoptersQuery();

        var result = await _mediator.Send(query);

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(Status200OK, Type = typeof(AdopterDto[]))]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> GetAdopterByIdAsync(Guid id)
    {
        var query = new GetAdopterByIdQuery() { Id = id };

        var result = await _mediator.Send(query);

        if (result.HasError<NotFoundError>())
            return NotFound();

        return Ok(result.Value);
    }

    [HttpPost]
    [ProducesResponseType(Status201Created, Type = typeof(AdopterDto))]
    [ProducesResponseType(Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> CreateAdopterAsync([FromBody] CreateAdopterCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.HasError<ValidationError>())
            return ValidationProblem();

        return CreatedAtAction(nameof(GetAdopterByIdAsync), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut()]
    [ProducesResponseType(Status200OK, Type = typeof(AdopterDto))]
    [ProducesResponseType(Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(Status404NotFound)]

    public async Task<IActionResult> UpdateAdopterAsync([FromBody] UpdateAdopterCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.HasError<NotFoundError>())
            return NotFound();

        if (result.HasError<ValidationError>())
            return ValidationProblem();

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(Status200OK, Type = typeof(AdopterDto))]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> DeleteAdopterAsync(Guid id)
    {
        var command = new DeleteAdopterCommand() { Id = id };

        var result = await _mediator.Send(command);

        if (result.HasError<NotFoundError>())
            return NotFound();

        return Ok(result.Value);
    }
}