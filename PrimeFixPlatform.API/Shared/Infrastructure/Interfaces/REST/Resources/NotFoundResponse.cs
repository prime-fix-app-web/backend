namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

/// <summary>
///     Represents a standardized response for HTTP 404 Not Found errors.
/// </summary>
public record NotFoundResponse()
{
    /// <summary>
    /// HTTP status code (404).
    /// </summary>
    public int Status { get; init; } = 404;

    /// <summary>
    /// Reason phrase (e.g., "Not Found").
    /// </summary>
    public string Error { get; init; } = "Not Found";

    /// <summary>
    /// Description of what was not found.
    /// </summary>
    public string Message { get; init; } = "The requested resource was not found.";
}