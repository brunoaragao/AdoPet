namespace Adopty.Application.Handlers;

public class UpdateAdopterByUserIdConsumer : IConsumer<UpdateAdopterByUserId>
{
    private readonly IAdopterRepository _repository;

    public UpdateAdopterByUserIdConsumer(IAdopterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<UpdateAdopterByUserId> context)
    {
        var message = context.Message;
        var adopter = await _repository.FindByUserIdAsync(message.UserId);

        if (adopter is null)
        {
            throw new KeyNotFoundException($"Adopter with user id {message.UserId} not found.");
        }

        adopter.UpdatePhoto(message.Photo);
        adopter.UpdateName(message.Name);
        adopter.UpdatePhone(message.Phone);
        adopter.UpdateCity(message.City);
        adopter.UpdateAbout(message.About);
        await _repository.UnitOfWork.CommitAsync();

        await context.RespondAsync(
            new UpdateAdopterByUserIdResult(
                adopter.Id,
                adopter.Photo,
                adopter.Name,
                adopter.Phone,
                adopter.City,
                adopter.About,
                adopter.UserId));
    }
}