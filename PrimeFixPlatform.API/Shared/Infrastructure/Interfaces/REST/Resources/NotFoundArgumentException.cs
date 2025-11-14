namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

public class NotFoundArgumentException : Exception
{
    public NotFoundArgumentException(string message) : base(message) { }
}