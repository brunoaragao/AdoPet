namespace Adopty.Application.Handlers;

public class UpdateAdopterConsumer : IConsumer<UpdateAdopter>
{
    private readonly IAdopterRepository _repository;

    public UpdateAdopterConsumer(IAdopterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<UpdateAdopter> context)
    {
        var message = context.Message;
        var adopter = await _repository.GetByIdAsync(message.Id);

        if (adopter is null)
        {
            throw new KeyNotFoundException($"Adopter with id {message.Id} not found.");
        }

        adopter.UpdatePhoto(message.Photo);
        adopter.UpdateName(message.Name);
        adopter.UpdatePhone(message.Phone);
        adopter.UpdateCity(message.City);
        adopter.UpdateAbout(message.About);
        await _repository.UnitOfWork.CommitAsync();

        await context.RespondAsync(
            new UpdateAdopterResult(
                adopter.Id,
                adopter.Photo,
                adopter.Name,
                adopter.Phone,
                adopter.City,
                adopter.About,
                adopter.UserId));
    }
}