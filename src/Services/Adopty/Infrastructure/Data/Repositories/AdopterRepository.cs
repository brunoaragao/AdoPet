namespace Adopty.Infrastructure.Data.Repositories;

public class AdopterRepository : GenericRepository<Adopter>, IAdopterRepository
{
    private readonly DbSet<Adopter> _adopters;

    public AdopterRepository(AdoptyContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
    {
        _adopters = context.Set<Adopter>();
    }

    public Task<Adopter?> FindByUserIdAsync(Guid userId)
    {
        return _adopters.SingleOrDefaultAsync(
            a => a.UserId == userId);
    }
}