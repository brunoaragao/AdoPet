namespace AdoPet.Services.PetAdoption.Domain.AggregateModels.ShelterAggregates;

public interface IShelterRepository : IRepository<Shelter>
{
    Task<IEnumerable<Shelter>> GetAllAsync();
    Task<Shelter?> GetByIdAsync(Guid id);
    void Add(Shelter shelter);
    void Update(Shelter shelter);
    void Delete(Shelter shelter);
}