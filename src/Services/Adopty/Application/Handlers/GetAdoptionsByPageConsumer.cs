namespace Adopty.Application.Handlers;

public class GetAdoptionsByPageConsumer : IConsumer<GetAdoptionsByPage>
{
    private readonly IAdoptionRepository _repository;

    public GetAdoptionsByPageConsumer(IAdoptionRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetAdoptionsByPage> context)
    {
        var message = context.Message;
        var adoptions = await _repository.GetByPageAsync(
            message.PageNumber,
            message.PageSize);

        await context.RespondAsync(
            new GetAdoptionsByPageResult(
                adoptions.Select(
                    adoption => new GetAdoptionsByPageResultItem(
                        adoption.Id,
                        adoption.AdopterId,
                        adoption.PetId))));
    }
}