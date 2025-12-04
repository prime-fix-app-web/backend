using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Response for a user account
/// </summary>
/// <param name="Id">
///     The unique identifier for the user account
/// </param>
/// <param name="Username">
///     The username of the user account
/// </param>
/// <param name="Email">
///     The email of the user account
/// </param>
/// <param name="RoleId">
///     The role identifier associated with the user account
/// </param>
/// <param name="UserId">
///     The user identifier associated with the user account
/// </param>
/// <param name="Password">
///     The password of the user account
/// </param>
/// <param name="IsNew">
///     Flag indicating if the user account is new
/// </param>
public record UserAccountResponse(
    int Id,
    string Username,
    string Email,
    [property: JsonPropertyName("role_id")] int RoleId,
    [property: JsonPropertyName("user_id")] int UserId,
    string Password,
    [property: JsonPropertyName("is_new")] bool IsNew);