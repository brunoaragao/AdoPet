namespace Adopty.Domain.Entities;

public class Pet : Entity
{
    public Pet(string photo, string name, string age, string size, string description, Guid shelterId)
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
    public Shelter? Shelter { get; private set; }
    public Adoption? Adoption { get; private set; }

    public void SetPhoto(string photo)
    {
        Photo = photo;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetAge(string age)
    {
        Age = age;
    }

    public void SetSize(string size)
    {
        Size = size;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetShelterId(Guid shelterId)
    {
        ShelterId = shelterId;
    }
}