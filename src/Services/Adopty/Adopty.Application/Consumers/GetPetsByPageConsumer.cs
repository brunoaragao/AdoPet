namespace Adopty.Application.Consumers;

public class GetPetsByPageConsumer : IConsumer<GetPetsByPage>
{
    private readonly IGenericRepository<Pet> _repository;

    public GetPetsByPageConsumer(IGenericRepository<Pet> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetPetsByPage> context)
    {
        var message = context.Message;
        var pets = await _repository.GetByPageAsync(message.Page, message.Size, p => p.Shelter);
        var result = new GetPetsByPageResult
        {
            Items = pets.Select(pet => new GetPetsByPageResultItem
            {
                Id = pet.Id,
                Photo = pet.Photo,
                Name = pet.Name,
                Age = pet.Age,
                Size = pet.Size,
                Description = pet.Description,
                ShelterId = pet.Shelter!.Id,
                ShelterAddress = pet.Shelter!.Address
            })
        };
        await context.RespondAsync(result);
    }
}