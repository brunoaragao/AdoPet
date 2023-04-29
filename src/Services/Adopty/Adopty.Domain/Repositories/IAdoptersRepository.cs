namespace Adopty.Domain.Repositories;

public interface IAdoptersRepository : IGenericRepository<Adopter>
{
    Task<Adopter> GetByUserIdAsync(Guid userId);
}