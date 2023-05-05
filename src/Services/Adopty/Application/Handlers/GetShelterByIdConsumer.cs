namespace Adopty.Application.Handlers;

public class GetShelterByIdConsumer : IConsumer<GetShelterById>
{
    private readonly IShelterRepository _repository;

    public GetShelterByIdConsumer(IShelterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetShelterById> context)
    {
        var message = context.Message;
        var shelter = await _repository.GetByIdAsync(message.Id);

        await context.RespondAsync(
            new GetShelterByIdResult(
                shelter!.Id,
                shelter.Address,
                shelter.UserId));
    }
}