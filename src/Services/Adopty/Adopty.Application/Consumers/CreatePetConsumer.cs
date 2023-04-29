namespace Adopty.Application.Consumers;

public class CreatePetConsumer : IConsumer<CreatePet>
{
    private readonly IGenericRepository<Pet> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePetConsumer(IGenericRepository<Pet> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<CreatePet> context)
    {
        var message = context.Message;
        var pet = new Pet(message.Photo, message.Name, message.Age, message.Size, message.Description, message.ShelterId);
        _repository.Add(pet);
        await _unitOfWork.CommitAsync();
        _repository.LoadReference(pet, p => p.Shelter);
        var result = new CreatePetResult
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