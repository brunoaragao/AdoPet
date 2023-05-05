namespace Adopty.Infrastructure.Data.Repositories;

public class ShelterRepository : GenericRepository<Shelter>, IShelterRepository
{
    public ShelterRepository(AdoptyContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
    {
    }
}