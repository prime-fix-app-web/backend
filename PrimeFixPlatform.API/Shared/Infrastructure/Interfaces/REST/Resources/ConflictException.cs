namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message) { }
}