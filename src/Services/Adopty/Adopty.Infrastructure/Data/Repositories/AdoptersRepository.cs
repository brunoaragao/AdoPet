namespace Adopty.Infrastructure.Data.Repositories;

public class AdoptersRepository : GenericRepository<Adopter>, IAdoptersRepository
{
    public AdoptersRepository(AdoptyContext context) : base(context) { }

    public async Task<Adopter> GetByUserIdAsync(Guid userId)
    {
        return await _dbSet.SingleAsync(x => x.UserId == userId);
    }
}