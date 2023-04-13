namespace AdoPet.Services.PetAdoption.Application.Dtos;

public class AdopterDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Address { get; set; }
    public required string Photo { get; set; }
    public required string Description { get; set; }
}