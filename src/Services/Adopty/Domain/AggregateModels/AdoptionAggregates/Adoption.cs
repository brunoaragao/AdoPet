namespace Adopty.Domain.AggregateModels.AdoptionAggregates;

public class Adoption : Entity, IAggregateRoot
{
    public Adoption(Guid adopterId, Guid petId)
    {
        AdopterId = adopterId;
        PetId = petId;
    }

    public Guid AdopterId { get; private set; }
    public Guid PetId { get; private set; }
}