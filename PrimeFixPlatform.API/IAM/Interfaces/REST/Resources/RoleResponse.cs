using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Response model for Role
/// </summary>
/// <param name="IdRole">
///     The unique identifier of the role
/// </param>
/// <param name="Name">
///     The name of the role
/// </param>
/// <param name="Description">
///     The description of the role
/// </param>
public record RoleResponse(
    [property: JsonPropertyName("id_role")] string IdRole,
    string Name,
    string Description);