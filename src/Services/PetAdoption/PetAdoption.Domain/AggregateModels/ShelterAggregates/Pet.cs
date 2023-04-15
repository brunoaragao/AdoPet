namespace AdoPet.Services.PetAdoption.Domain.AggregateModels.ShelterAggregates;

public class Pet : Entity
{
    public Pet(string name, string age, string size, string description, string photo)
    {
        Name = name;
        Age = age;
        Size = size;
        Description = description;
        Photo = photo;
    }

    public string Name { get; private set; }
    public string Age { get; private set; }
    public string Size { get; private set; }
    public string Description { get; private set; }
    public string Photo { get; private set; }

    public void Update(string name, string age, string size, string description, string photo)
    {
        Name = name;
        Age = age;
        Size = size;
        Description = description;
        Photo = photo;
    }
}