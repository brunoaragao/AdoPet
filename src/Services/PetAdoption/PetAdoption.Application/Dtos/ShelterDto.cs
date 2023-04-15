namespace AdoPet.Services.PetAdoption.Application.Dtos
{
    public class ShelterDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
    }
}