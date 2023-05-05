namespace Adopty.Application.Handlers;

public class UpdatePetConsumer : IConsumer<UpdatePet>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;

    public UpdatePetConsumer(IPetRepository petRepository, IShelterRepository shelterRepository)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
    }

    public async Task Consume(ConsumeContext<UpdatePet> context)
    {
        var message = context.Message;
        var pet = await _petRepository.GetByIdAsync(message.Id);

        if (pet is null)
        {
            throw new KeyNotFoundException($"Pet with id {message.Id} not found.");
        }

        pet.UpdatePhoto(message.Photo);
        pet.UpdateName(message.Name);
        pet.UpdateAge(message.Age);
        pet.UpdateSize(message.Size);
        pet.UpdateDescription(message.Description);
        await _petRepository.UnitOfWork.CommitAsync();

        var shelter = await _shelterRepository.GetByIdAsync(pet.ShelterId);
        await context.RespondAsync(
            new UpdatePetResult(
                pet.Id,
                pet.Photo,
                pet.Name,
                pet.Age,
                pet.Size,
                pet.Description,
                pet.ShelterId,
                shelter!.Address));
    }
}