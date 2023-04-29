namespace Adopty.Domain.Entities;

public class Adoption : Entity
{
    public Adoption(Guid adopterId, Guid petId)
    {
        AdopterId = adopterId;
        PetId = petId;
    }

    public Guid AdopterId { get; private set; }
    public Guid PetId { get; private set; }
    public Pet? Pet { get; private set; }
    public Adopter? Adopter { get; private set; }

    public void SetAdopterId(Guid adopterId)
    {
        AdopterId = adopterId;
    }

    public void SetPetId(Guid petId)
    {
        PetId = petId;
    }
}