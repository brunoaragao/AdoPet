namespace Adopty.Application.Handlers;

public class GetAdopterByIdConsumer : IConsumer<GetAdopterById>
{
    private readonly IAdopterRepository _repository;

    public GetAdopterByIdConsumer(IAdopterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetAdopterById> context)
    {
        var message = context.Message;
        var adopter = await _repository.GetByIdAsync(message.Id);

        if (adopter is null)
        {
            throw new KeyNotFoundException($"Adopter with id {message.Id} not found.");
        }

        await context.RespondAsync(
            new GetAdopterByIdResult(
                adopter.Id,
                adopter.Photo,
                adopter.Name,
                adopter.Phone,
                adopter.City,
                adopter.About,
                adopter.UserId));
    }
}