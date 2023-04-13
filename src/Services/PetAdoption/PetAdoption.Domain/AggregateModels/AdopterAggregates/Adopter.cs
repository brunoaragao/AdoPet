namespace AdoPet.Services.PetAdoption.Domain.AggregateModels.AdopterAggregates;

public class Adopter : Entity, IAggregateRoot
{
    public Adopter(string name, string email, string phone, string address, string photo, string description)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        Photo = photo;
        Description = description;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }
    public string Photo { get; private set; }
    public string Description { get; private set; }

    public void Update(string name, string email, string phone, string address, string photo, string description)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        Photo = photo;
        Description = description;
    }
}