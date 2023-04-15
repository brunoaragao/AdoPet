namespace AdoPet.Services.PetAdoption.Domain.AggregateModels.ShelterAggregates;

public class Adoption : Entity
{
    public Adoption(Guid petId, Guid adopterId)
    {
        PetId = petId;
        AdopterId = adopterId;
    }

    public Guid PetId { get; private set; }
    public Guid AdopterId { get; private set; }
}