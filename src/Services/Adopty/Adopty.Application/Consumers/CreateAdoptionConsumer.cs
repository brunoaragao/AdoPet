namespace Adopty.Application.Consumers;

public class CreateAdoptionConsumer : IConsumer<CreateAdoption>
{
    private readonly IGenericRepository<Adoption> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAdoptionConsumer(IGenericRepository<Adoption> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<CreateAdoption> context)
    {
        var message = context.Message;
        var adoption = new Adoption(message.AdopterId, message.PetId);
        _repository.Add(adoption);
        await _unitOfWork.CommitAsync();
        var result = new CreateAdoptionResult
        {
            Id = adoption.Id,
            AdopterId = adoption.AdopterId,
            PetId = adoption.PetId
        };
        await context.RespondAsync(result);
    }
}