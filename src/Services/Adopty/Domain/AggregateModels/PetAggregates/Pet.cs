namespace Adopty.Domain.AggregateModels.PetAggregates;

public class Pet : Entity, IAggregateRoot
{
    public Pet(
        string photo,
        string name,
        string age,
        string size,
        string description,
        Guid shelterId)
    {
        Photo = photo;
        Name = name;
        Age = age;
        Size = size;
        Description = description;
        ShelterId = shelterId;
    }

    public string Photo { get; private set; }
    public string Name { get; private set; }
    public string Age { get; private set; }
    public string Size { get; private set; }
    public string Description { get; private set; }
    public Guid ShelterId { get; private set; }

    public void UpdatePhoto(string photo)
    {
        Photo = photo;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateAge(string age)
    {
        Age = age;
    }

    public void UpdateSize(string size)
    {
        Size = size;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }
}