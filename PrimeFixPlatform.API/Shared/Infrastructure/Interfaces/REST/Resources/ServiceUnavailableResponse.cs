namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

/// <summary>
/// Standard response for 503 Service Unavailable.
/// </summary>
public record ServiceUnavailableResponse
{
    /// <summary>
    ///     Status code for Service Unavailable (503).
    /// </summary>
    public int Status { get; init; } = 503;
    /// <summary>
    ///     Error description.
    /// </summary>
    public string Error { get; init; } = "Service Unavailable";
    /// <summary>
    ///     Message providing additional details about the error.
    /// </summary>
    public string Message { get; init; } = "The service is currently unavailable. Please try again later.";
}