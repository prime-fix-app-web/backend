namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

/// <summary>
///     Represents a standardized response for HTTP 409 Conflict errors.
/// </summary>
public record ConflictResponse
{
    /// <summary>
    ///     Status code (409).
    /// </summary>
    public int Status { get; init; } = 409;
    /// <summary>
    ///     Reason phrase (e.g., "Conflict").
    /// </summary>
    public string Error { get; init; } = "Conflict";
    /// <summary>
    ///     Message describing the conflict.
    /// </summary>
    public string Message { get; init; } = "The request could not be completed due to a conflict with the current state of the resource.";
}