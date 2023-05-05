namespace Adopty.Domain.AggregateModels.AdopterAggregates;

public class Adopter : Entity, IAggregateRoot
{
    public Adopter(
        Guid userId,
        string? photo = null,
        string? name = null,
        string? phone = null,
        string? city = null,
        string? about = null)
    {
        Photo = photo;
        Name = name;
        Phone = phone;
        City = city;
        About = about;
        UserId = userId;
    }

    public string? Photo { get; private set; }
    public string? Name { get; private set; }
    public string? Phone { get; private set; }
    public string? City { get; private set; }
    public string? About { get; private set; }
    public Guid UserId { get; private set; }

    public void UpdatePhoto(string? photo)
    {
        Photo = photo;
    }

    public void UpdateName(string? name)
    {
        Name = name;
    }

    public void UpdatePhone(string? phone)
    {
        Phone = phone;
    }

    public void UpdateCity(string? city)
    {
        City = city;
    }

    public void UpdateAbout(string? about)
    {
        About = about;
    }
}