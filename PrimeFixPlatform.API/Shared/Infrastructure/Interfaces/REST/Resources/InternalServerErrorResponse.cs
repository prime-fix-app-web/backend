namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

/// <summary>
/// Standard response for 500 Internal Server Error.
/// </summary>
public record InternalServerErrorResponse
{
    /// <summary>
    ///     Status code for Internal Server Error (500).
    /// </summary>
    public int Status { get; init; } = 500;
    /// <summary>
    ///     Error description.
    /// </summary>
    public string Error { get; init; } = "Internal Server Error";
    /// <summary>
    ///     Message providing additional details about the error.
    /// </summary>
    public string Message { get; init; } = "An unexpected error occurred on the server.";
}