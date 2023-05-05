namespace Adopty.Domain.AggregateModels.AdopterAggregates;

public interface IAdopterRepository : IGenericRepository<Adopter>
{
    Task<Adopter?> FindByUserIdAsync(Guid userId);
}