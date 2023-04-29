namespace Adopty.Application.Consumers;

public class GetAdoptionByIdConsumer : IConsumer<GetAdoptionById>
{
    private readonly IGenericRepository<Adoption> _repository;

    public GetAdoptionByIdConsumer(IGenericRepository<Adoption> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetAdoptionById> context)
    {
        var message = context.Message;
        var adoption = await _repository.GetByIdAsync(message.Id);
        var result = new GetAdoptionByIdResult
        {
            Id = adoption.Id,
            AdopterId = adoption.AdopterId,
            PetId = adoption.PetId
        };
        await context.RespondAsync(result);
    }
}