namespace AdoPet.Services.PetAdoption.Domain.AggregateModels.AdopterAggregates;

public interface IAdopterRepository : IRepository<Adopter>
{
    Task<IEnumerable<Adopter>> GetAllAsync();
    Task<Adopter?> GetByIdAsync(Guid id);
    void Add(Adopter adopter);
    void Update(Adopter adopter);
    void Delete(Adopter adopter);
}