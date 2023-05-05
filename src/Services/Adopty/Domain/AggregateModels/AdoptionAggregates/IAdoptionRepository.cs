namespace Adopty.Domain.AggregateModels.AdoptionAggregates;

public interface IAdoptionRepository : IRepository<Adoption>
{
    void Add(Adoption entity);
    void Delete(Adoption entity);
    Task<Adoption?> GetByIdAsync(Guid id);
    Task<IEnumerable<Adoption>> GetByPageAsync(int pageNumber, int pageSize);
}