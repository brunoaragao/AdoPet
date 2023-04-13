namespace AdoPet.Services.PetAdoption.Application.Errors;

public class NotFoundError : Error
{
    public NotFoundError(string message) : base(message)
    {
    }
}