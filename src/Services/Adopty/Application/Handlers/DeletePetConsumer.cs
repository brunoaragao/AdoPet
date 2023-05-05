namespace Adopty.Application.Handlers;

public class DeletePetConsumer : IConsumer<DeletePet>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;

    public DeletePetConsumer(
        IPetRepository petRepository,
        IShelterRepository shelterRepository)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
    }

    public async Task Consume(ConsumeContext<DeletePet> context)
    {
        var message = context.Message;
        var pet = await _petRepository.GetByIdAsync(message.Id);

        if (pet is null)
        {
            throw new KeyNotFoundException($"Pet with id {message.Id} not found.");
        }

        _petRepository.Delete(pet);
        await _petRepository.UnitOfWork.CommitAsync();

        var shelter = await _shelterRepository.GetByIdAsync(pet.ShelterId);
        await context.RespondAsync(
            new DeletePetResult(
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