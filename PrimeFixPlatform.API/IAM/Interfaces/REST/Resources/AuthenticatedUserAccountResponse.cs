namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
///     Represents the response data for an authenticated user account.
/// </summary>
/// <param name="Id">
///     The unique identifier of the authenticated user account.
/// </param>
/// <param name="Username">
///     The username of the authenticated user account.
/// </param>
/// <param name="Token">
///     The authentication token for the user account.
/// </param>
public record AuthenticatedUserAccountResponse(
    int Id, 
    string Username,
    string Token);