using static Microsoft.AspNetCore.Http.StatusCodes;

namespace AdoPet.Services.PetAdoption.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(Status200OK, Type = typeof(PetDto[]))]
    public async Task<IActionResult> GetPetsAsync()
    {
        var query = new GetPetsQuery();

        var result = await _mediator.Send(query);

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(Status200OK, Type = typeof(PetDto[]))]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> GetPetByIdAsync(Guid id)
    {
        var query = new GetPetByIdQuery() { Id = id };

        var result = await _mediator.Send(query);

        if (result.HasError<NotFoundError>())
            return NotFound();

        return Ok(result.Value);
    }

    [HttpPost]
    [ProducesResponseType(Status201Created, Type = typeof(PetDto))]
    [ProducesResponseType(Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(Status409Conflict)]
    public async Task<IActionResult> CreatePetAsync([FromBody] CreatePetCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.HasError<ValidationError>())
            return ValidationProblem();

        if (result.HasError<ConflictError>())
            return Conflict();

        return CreatedAtAction(nameof(GetPetByIdAsync), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut()]
    [ProducesResponseType(Status200OK, Type = typeof(PetDto))]
    [ProducesResponseType(Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(Status404NotFound)]
    [ProducesResponseType(Status409Conflict)]
    public async Task<IActionResult> UpdatePetAsync([FromBody] UpdatePetCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.HasError<ValidationError>())
            return ValidationProblem();

        if (result.HasError<NotFoundError>())
            return NotFound();

        if(result.HasError<ConflictError>())
            return Conflict();

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(Status200OK, Type = typeof(PetDto))]
    [ProducesResponseType(Status404NotFound)]
    public async Task<IActionResult> DeletePetAsync(Guid id)
    {
        var command = new DeletePetCommand() { Id = id };

        var result = await _mediator.Send(command);

        if (result.HasError<NotFoundError>())
            return NotFound();

        return Ok(result.Value);
    }
}