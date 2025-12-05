namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

/// <summary>
///     Response for 401 Unauthorized errors.
/// </summary>
public record UnauthorizedResponse
{
    /// <summary>
    ///     Status code for Unauthorized (401).
    /// </summary>
    public int Status { get; init; }
    /// <summary>
    ///     Error description.
    /// </summary>
    public string Error { get; init; } = string.Empty;

    /// <summary>
    ///     Message providing additional details about the error.
    /// </summary>
    public string Message { get; init; } = "Authentication token is missing or invalid.";
}