namespace Adopty.Api.Controllers;

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
    public async Task<IActionResult> GetAdoptersByPage(int page = 1, int size = 10)
    {
        var request = new GetAdoptersByPage { Page = page, Size = size };
        var client = _mediator.CreateRequestClient<GetAdoptersByPage>();
        var response = await client.GetResponse<GetAdoptersByPageResult>(request);
        return Ok(response.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdopterById(Guid id)
    {
        var request = new GetAdopterById { Id = id };
        var client = _mediator.CreateRequestClient<GetAdopterById>();
        var response = await client.GetResponse<GetAdopterByIdResult>(request);
        return Ok(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdopter(CreateAdopter request)
    {
        var client = _mediator.CreateRequestClient<CreateAdopter>();
        var response = await client.GetResponse<CreateAdopterResult>(request);
        return CreatedAtAction(nameof(GetAdopterById), new { id = response.Message.Id }, response.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAdopter(UpdateAdopter message)
    {
        var client = _mediator.CreateRequestClient<UpdateAdopter>();
        var response = await client.GetResponse<UpdateAdopterResult>(message);
        return Ok(response.Message);
    }

    [HttpPost("UpdateAdopterByUserId")]
    public async Task<IActionResult> UpdateAdopterByUserIdAsync(UpdateAdopterByUserId message)
    {
        var client = _mediator.CreateRequestClient<UpdateAdopterByUserId>();
        var response = await client.GetResponse<UpdateAdopterByUserIdResult>(message);
        return Ok(response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdopter(Guid id)
    {
        var request = new DeleteAdopter { Id = id };
        var client = _mediator.CreateRequestClient<DeleteAdopter>();
        var response = await client.GetResponse<DeleteAdopterResult>(request);
        return Ok(response.Message);
    }
}

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
    public async Task<IActionResult> GetSheltersByPage(int page = 1, int size = 10)
    {
        var request = new GetSheltersByPage { Page = page, Size = size };
        var client = _mediator.CreateRequestClient<GetSheltersByPage>();
        var response = await client.GetResponse<GetSheltersByPageResult>(request);
        return Ok(response.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShelterById(Guid id)
    {
        var request = new GetShelterById { Id = id };
        var client = _mediator.CreateRequestClient<GetShelterById>();
        var response = await client.GetResponse<GetShelterByIdResult>(request);
        return Ok(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShelter(CreateShelter request)
    {
        var client = _mediator.CreateRequestClient<CreateShelter>();
        var response = await client.GetResponse<CreateShelterResult>(request);
        return CreatedAtAction(nameof(GetShelterById), new { id = response.Message.Id }, response.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateShelter(UpdateShelter message)
    {
        var client = _mediator.CreateRequestClient<UpdateShelter>();
        var response = await client.GetResponse<UpdateShelterResult>(message);
        return Ok(response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShelter(Guid id)
    {
        var request = new DeleteShelter { Id = id };
        var client = _mediator.CreateRequestClient<DeleteShelter>();
        var response = await client.GetResponse<DeleteShelterResult>(request);
        return Ok(response.Message);
    }
}