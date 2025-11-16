namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

/// <summary>
///     Represents a standardized response for HTTP 404 Not Found errors.
/// </summary>
public record NotFoundResponse()
{
    /// <summary>
    /// HTTP status code (404).
    /// </summary>
    public int Status { get; init; }

    /// <summary>
    /// Reason phrase (e.g., "Not Found").
    /// </summary>
    public string Error { get; init; } = string.Empty;

    /// <summary>
    /// Description of what was not found.
    /// </summary>
    public string Message { get; init; } = string.Empty;
}