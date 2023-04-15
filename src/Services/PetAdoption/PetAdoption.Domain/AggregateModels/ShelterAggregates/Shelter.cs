namespace AdoPet.Services.PetAdoption.Domain.AggregateModels.ShelterAggregates;

public class Shelter : Entity, IAggregateRoot
{
    private readonly List<Pet> _pets = new List<Pet>();
    private readonly List<Adoption> _adoptions = new List<Adoption>();

    public Shelter(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public string Name { get; private set; }
    public string Address { get; private set; }
    public IReadOnlyCollection<Pet> Pets => _pets.AsReadOnly();
    public IReadOnlyCollection<Adoption> Adoptions => _adoptions.AsReadOnly();

    public void Update(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }

    public void RemovePet(Pet pet)
    {
        _pets.Remove(pet);
    }

    public void AddAdoption(Adoption adoption)
    {
        if(_adoptions.Any(a => a.PetId == adoption.PetId))
            throw new InvalidOperationException($"Pet with id {adoption.PetId} is already adopted");

        _adoptions.Add(adoption);
    }

    public void RemoveAdoption(Adoption adoption)
    {
        if(!_adoptions.Any(a => a.PetId == adoption.PetId))
            throw new InvalidOperationException($"Pet with id {adoption.PetId} is not adopted");

        _adoptions.Remove(adoption);
    }
}