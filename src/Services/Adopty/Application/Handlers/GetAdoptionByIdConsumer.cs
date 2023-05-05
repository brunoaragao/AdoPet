namespace Adopty.Application.Handlers;

public class GetAdoptionByIdConsumer : IConsumer<GetAdoptionById>
{
    private readonly IAdoptionRepository _repository;

    public GetAdoptionByIdConsumer(IAdoptionRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetAdoptionById> context)
    {
        var message = context.Message;
        var adoption = await _repository.GetByIdAsync(message.Id);

        if (adoption is null)
        {
            throw new KeyNotFoundException($"Adoption with id {message.Id} not found.");
        }

        await context.RespondAsync(
            new GetAdoptionByIdResult(
                adoption.Id,
                adoption.AdopterId,
                adoption.PetId));
    }
}