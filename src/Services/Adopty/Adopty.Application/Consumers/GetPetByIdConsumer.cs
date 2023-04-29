namespace Adopty.Application.Consumers;

public class GetPetByIdConsumer : IConsumer<GetPetById>
{
    private readonly IGenericRepository<Pet> _repository;

    public GetPetByIdConsumer(IGenericRepository<Pet> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetPetById> context)
    {
        var message = context.Message;
        var pet = await _repository.GetByIdAsync(message.Id, p => p.Shelter);
        var result = new GetPetByIdResult
        {
            Id = pet.Id,
            Photo = pet.Photo,
            Name = pet.Name,
            Age = pet.Age,
            Size = pet.Size,
            Description = pet.Description,
            ShelterId = pet.Shelter!.Id,
            ShelterAddress = pet.Shelter!.Address
        };
        await context.RespondAsync(result);
    }
}