namespace Adopty.Application.Handlers;

public class CreatePetConsumer : IConsumer<CreatePet>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;

    public CreatePetConsumer(
        IPetRepository petRepository,
        IShelterRepository shelterRepository)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
    }

    public async Task Consume(ConsumeContext<CreatePet> context)
    {
        var message = context.Message;
        var pet = new Pet(
            message.Photo,
            message.Name,
            message.Age,
            message.Size,
            message.Description,
            message.ShelterId);

        _petRepository.Add(pet);
        await _petRepository.UnitOfWork.CommitAsync();

        var shelter = await _shelterRepository.GetByIdAsync(pet.ShelterId);
        await context.RespondAsync(
            new CreatePetResult(
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