namespace Adopty.Application.Consumers;

public class DeletePetConsumer : IConsumer<DeletePet>
{
    private readonly IGenericRepository<Pet> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePetConsumer(IGenericRepository<Pet> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<DeletePet> context)
    {
        var message = context.Message;
        var pet = await _repository.GetByIdAsync(message.Id);
        _repository.LoadReference(pet, p => p.Shelter);
        _repository.Delete(pet);
        await _unitOfWork.CommitAsync();
        var result = new DeletePetResult
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