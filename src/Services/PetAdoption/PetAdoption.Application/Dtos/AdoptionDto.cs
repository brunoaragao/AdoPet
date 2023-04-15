namespace AdoPet.Services.PetAdoption.Application.Dtos;

public class AdoptionDto
{
    public required Guid Id { get; set; }
    public required Guid PetId { get; set; }
    public required Guid AdopterId { get; set; }
}
