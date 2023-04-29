namespace Adopty.Application.Consumers;

public class UpdateShelterConsumer : IConsumer<UpdateShelter>
{
    private readonly IGenericRepository<Shelter> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateShelterConsumer(IGenericRepository<Shelter> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<UpdateShelter> context)
    {
        var message = context.Message;
        var shelter = await _repository.GetByIdAsync(message.Id);
        shelter.SetAddress(message.Address);
        shelter.SetUserId(message.UserId);
        await _unitOfWork.CommitAsync();
        var result = new UpdateShelterResult
        {
            Id = shelter.Id,
            Address = shelter.Address,
            UserId = shelter.UserId
        };
        await context.RespondAsync(result);
    }
}