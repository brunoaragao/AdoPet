namespace Adopty.Application.Consumers;

public class CreateShelterConsumer : IConsumer<CreateShelter>
{
    private readonly IGenericRepository<Shelter> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateShelterConsumer(IGenericRepository<Shelter> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<CreateShelter> context)
    {
        var message = context.Message;
        var shelter = new Shelter(message.Address, message.UserId);
        _repository.Add(shelter);
        await _unitOfWork.CommitAsync();
        var result = new CreateShelterResult
        {
            Id = shelter.Id,
            Address = shelter.Address,
            UserId = shelter.UserId
        };
        await context.RespondAsync(result);
    }
}