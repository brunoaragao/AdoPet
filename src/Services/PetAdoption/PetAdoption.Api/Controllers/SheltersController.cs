using static Microsoft.AspNetCore.Http.StatusCodes;

namespace AdoPet.Services.PetAdoption.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SheltersController : ControllerBase
{
    private readonly IMediator _mediator;

    public SheltersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(Status200OK, Type = typeof(ShelterDto[]))]
    public async Task<IActionResult> GetSheltersAsync()
    {
        var query = new GetSheltersQuery();

        var result = await _mediator.Send(query);

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(Status200OK, Type = typeof(ShelterDto[]))]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> GetShelterByIdAsync(Guid id)
    {
        var query = new GetShelterByIdQuery() { Id = id };

        var result = await _mediator.Send(query);

        if (result.HasError<NotFoundError>())
            return NotFound();

        return Ok(result.Value);
    }

    [HttpPost]
    [ProducesResponseType(Status201Created, Type = typeof(ShelterDto))]
    [ProducesResponseType(Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> CreateShelterAsync([FromBody] CreateShelterCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.HasError<ValidationError>())
            return ValidationProblem();

        return CreatedAtAction(nameof(GetShelterByIdAsync), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut()]
    [ProducesResponseType(Status200OK, Type = typeof(ShelterDto))]
    [ProducesResponseType(Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(Status404NotFound)]

    public async Task<IActionResult> UpdateShelterAsync([FromBody] UpdateShelterCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.HasError<ValidationError>())
            return ValidationProblem();

        if (result.HasError<NotFoundError>())
            return NotFound();

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(Status200OK, Type = typeof(ShelterDto))]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> DeleteShelterAsync(Guid id)
    {
        var command = new DeleteShelterCommand() { Id = id };

        var result = await _mediator.Send(command);

        if (result.HasError<NotFoundError>())
            return NotFound();

        return Ok(result.Value);
    }
}