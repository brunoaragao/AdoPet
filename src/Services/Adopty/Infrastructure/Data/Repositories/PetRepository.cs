namespace Adopty.Infrastructure.Data.Repositories;

public class PetRepository : GenericRepository<Pet>, IPetRepository
{
    public PetRepository(AdoptyContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
    {
    }
}