namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

/// <summary>
///     Represents a standardized response for HTTP 409 Conflict errors.
/// </summary>
public record ConflictResponse
{
    /// <summary>
    ///     Status code (409).
    /// </summary>
    public int Status { get; init; }
    /// <summary>
    ///     Reason phrase (e.g., "Conflict").
    /// </summary>
    public string Error { get; init; } = string.Empty;
    /// <summary>
    ///     Message describing the conflict.
    /// </summary>
    public string Message { get; init; } = string.Empty;
}