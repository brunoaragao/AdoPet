namespace Adopty.Application.Handlers;

public class GetPetsByPageConsumer : IConsumer<GetPetsByPage>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;

    public GetPetsByPageConsumer(
        IPetRepository petRepository,
        IShelterRepository shelterRepository)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
    }

    public async Task Consume(ConsumeContext<GetPetsByPage> context)
    {
        var message = context.Message;
        var pets = await _petRepository.GetByPageAsync(
            message.PageNumber,
             message.PageSize);

        var shelters = await _shelterRepository.GetByIdsAsync(
            pets.Select(
                pet => pet.ShelterId));

        await context.RespondAsync(
            new GetPetsByPageResult(
                pets.Select(
                    pet => new GetPetsByPageResultItem(
                        pet.Id,
                        pet.Photo,
                        pet.Name,
                        pet.Age,
                        pet.Size,
                        pet.Description,
                        pet.ShelterId,
                        shelters.Single(
                            s => s.Id == pet.ShelterId).Address))));
    }
}