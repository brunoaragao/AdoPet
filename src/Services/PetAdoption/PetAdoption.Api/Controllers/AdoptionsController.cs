using static Microsoft.AspNetCore.Http.StatusCodes;

namespace AdoPet.Services.PetAdoption.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AdoptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdoptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(Status200OK, Type = typeof(AdoptionDto[]))]
    public async Task<IActionResult> GetAdoptionsAsync()
    {
        var query = new GetAdoptionsQuery();

        var result = await _mediator.Send(query);

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(Status200OK, Type = typeof(AdoptionDto[]))]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> GetAdoptionByIdAsync(Guid id)
    {
        var query = new GetAdoptionByIdQuery() { Id = id };

        var result = await _mediator.Send(query);

        if (result.HasError<NotFoundError>())
            return NotFound();

        return Ok(result.Value);
    }

    [HttpPost]
    [ProducesResponseType(Status201Created, Type = typeof(AdoptionDto))]
    [ProducesResponseType(Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(Status409Conflict)]
    public async Task<IActionResult> CreateAdoptionAsync([FromBody] CreateAdoptionCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.HasError<ValidationError>())
            return ValidationProblem();

        if (result.HasError<ConflictError>())
            return Conflict();

        return CreatedAtAction(nameof(GetAdoptionByIdAsync), new { id = result.Value.Id }, result.Value);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(Status200OK, Type = typeof(AdoptionDto))]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> DeleteAdoptionAsync(Guid id)
    {
        var command = new DeleteAdoptionCommand() { Id = id };

        var result = await _mediator.Send(command);

        if (result.HasError<NotFoundError>())
            return NotFound();

        return Ok(result.Value);
    }
}