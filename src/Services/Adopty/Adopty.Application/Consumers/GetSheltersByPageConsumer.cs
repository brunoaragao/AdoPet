namespace Adopty.Application.Consumers;

public class GetSheltersByPageConsumer : IConsumer<GetSheltersByPage>
{
    private readonly IGenericRepository<Shelter> _repository;

    public GetSheltersByPageConsumer(IGenericRepository<Shelter> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetSheltersByPage> context)
    {
        var message = context.Message;
        var shelters = await _repository.GetByPageAsync(message.Page, message.Size);
        var result = new GetSheltersByPageResult
        {
            Items = shelters.Select(shelter => new GetSheltersByPageResultItem
            {
                Id = shelter.Id,
                Address = shelter.Address,
                UserId = shelter.UserId
            })
        };
        await context.RespondAsync(result);
    }
}