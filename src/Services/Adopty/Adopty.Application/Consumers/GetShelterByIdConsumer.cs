namespace Adopty.Application.Consumers;

public class GetShelterByIdConsumer : IConsumer<GetShelterById>
{
    private readonly IGenericRepository<Shelter> _repository;

    public GetShelterByIdConsumer(IGenericRepository<Shelter> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetShelterById> context)
    {
        var message = context.Message;
        var shelter = await _repository.GetByIdAsync(message.Id);
        var result = new GetShelterByIdResult
        {
            Id = shelter.Id,
            Address = shelter.Address,
            UserId = shelter.UserId
        };
        await context.RespondAsync(result);
    }
}