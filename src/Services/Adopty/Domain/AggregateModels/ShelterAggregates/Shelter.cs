namespace Adopty.Domain.AggregateModels.ShelterAggregates;

public class Shelter : Entity, IAggregateRoot
{
    public Shelter(Guid userId, string? address = null)
    {
        Address = address;
        UserId = userId;
    }

    public string? Address { get; private set; }
    public Guid UserId { get; private set; }

    public void UpdateAddress(string? address)
    {
        Address = address;
    }
}