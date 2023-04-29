namespace Adopty.Application.Consumers;

public class GetAdoptionsByPageConsumer : IConsumer<GetAdoptionsByPage>
{
    private readonly IGenericRepository<Adoption> _repository;

    public GetAdoptionsByPageConsumer(IGenericRepository<Adoption> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetAdoptionsByPage> context)
    {
        var message = context.Message;
        var adoptions = await _repository.GetByPageAsync(message.Page, message.Size);
        var result = new GetAdoptionsByPageResult
        {
            Items = adoptions.Select(adoption => new GetAdoptionsByPageResultItem
            {
                Id = adoption.Id,
                AdopterId = adoption.AdopterId,
                PetId = adoption.PetId
            })
        };
        await context.RespondAsync(result);
    }
}