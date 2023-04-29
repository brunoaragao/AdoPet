namespace Adopty.Application.Consumers;

public class UpdatePetConsumer : IConsumer<UpdatePet>
{
    private readonly IGenericRepository<Pet> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePetConsumer(IGenericRepository<Pet> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<UpdatePet> context)
    {
        var message = context.Message;
        var pet = await _repository.GetByIdAsync(message.Id);
        pet.SetPhoto(message.Photo);
        pet.SetName(message.Name);
        pet.SetAge(message.Age);
        pet.SetSize(message.Size);
        pet.SetDescription(message.Description);
        pet.SetShelterId(message.ShelterId);
        await _unitOfWork.CommitAsync();
        _repository.LoadReference(pet, p => p.Shelter);
        var result = new UpdatePetResult
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