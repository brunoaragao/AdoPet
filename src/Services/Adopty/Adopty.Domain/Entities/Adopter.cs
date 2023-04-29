namespace Adopty.Domain.Entities;

public class Adopter : Entity
{
    public Adopter(string? photo, string? name, string? phone, string? city, string? about, Guid userId)
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
    public IEnumerable<Adoption>? Adoptions { get; private set; }

    public void SetPhoto(string? photo)
    {
        Photo = photo;
    }

    public void SetName(string? name)
    {
        Name = name;
    }

    public void SetPhone(string? phone)
    {
        Phone = phone;
    }

    public void SetCity(string? city)
    {
        City = city;
    }

    public void SetAbout(string? about)
    {
        About = about;
    }

    public void SetUserId(Guid userId)
    {
        UserId = userId;
    }
}