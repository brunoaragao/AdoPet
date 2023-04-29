namespace Adopty.Domain.Entities;

public class Shelter : Entity
{
    public Shelter(string? address, Guid userId)
    {
        Address = address;
        UserId = userId;
    }

    public string? Address { get; private set; }
    public Guid UserId { get; private set; }
    public IEnumerable<Pet>? Pets { get; private set; }

    public void SetAddress(string? address)
    {
        Address = address;
    }

    public void SetUserId(Guid userId)
    {
        UserId = userId;
    }
}