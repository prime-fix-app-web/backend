namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

public class NotFoundIdException : Exception
{
    public NotFoundIdException(string message) : base(message)
    {
    }
}