namespace AdoPet.Services.PetAdoption.Application.Errors;

public class ConflictError : Error
{
    public ConflictError(string message) : base(message)
    {
    }
}