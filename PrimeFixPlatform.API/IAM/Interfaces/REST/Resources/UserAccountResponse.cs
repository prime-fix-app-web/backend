using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Response for a user account
/// </summary>
/// <param name="IdUserAccount">
///     The unique identifier for the user account
/// </param>
/// <param name="Username">
///     The username of the user account
/// </param>
/// <param name="Email">
///     The email of the user account
/// </param>
/// <param name="IdRole">
///     The role identifier associated with the user account
/// </param>
/// <param name="IdUser">
///     The user identifier associated with the user account
/// </param>
/// <param name="Password">
///     The password of the user account
/// </param>
/// <param name="IsNew">
///     Flag indicating if the user account is new
/// </param>
public record UserAccountResponse(
    [property: JsonPropertyName("id_user_account")] string IdUserAccount,
    string Username,
    string Email,
    [property: JsonPropertyName("id_role")] string IdRole,
    [property: JsonPropertyName("id_user")] string IdUser,
    string Password,
    [property: JsonPropertyName("is_new")] bool IsNew);