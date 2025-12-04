namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Response model for Role
/// </summary>
/// <param name="Id">
///     The unique identifier of the role
/// </param>
/// <param name="Name">
///     The name of the role
/// </param>
/// <param name="Description">
///     The description of the role
/// </param>
public record RoleResponse(
    int Id,
    string Name,
    string Description);