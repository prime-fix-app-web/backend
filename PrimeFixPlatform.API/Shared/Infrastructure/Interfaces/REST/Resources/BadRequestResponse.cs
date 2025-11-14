namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

/// <summary>
///     Represents a standardized response for HTTP 400 Bad Request errors.
/// </summary>
public record BadRequestResponse()
{
    /// <summary>
    /// HTTP status code (400).
    /// </summary>
    public int Status { get; init; }

    /// <summary>
    /// Reason phrase (e.g., "Bad Request").
    /// </summary>
    public string Error { get; init; } = string.Empty;

    /// <summary>
    /// High-level error message.
    /// </summary>
    public string Message { get; init; } = string.Empty;

    /// <summary>
    /// Detailed validation errors (field -> list of messages).
    /// </summary>
    public IDictionary<string, string[]> Errors { get; init; } =
        new Dictionary<string, string[]>();
}