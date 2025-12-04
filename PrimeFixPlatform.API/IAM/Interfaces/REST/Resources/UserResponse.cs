using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Represents the user response
/// </summary>
/// <param name="IdUser">
///     The user identifier
/// </param>
/// <param name="Name">
///     The name of the user
/// </param>
/// <param name="LastName">
///     The last name of the user
/// </param>
/// <param name="Dni">
///     The dni of the user
/// </param>
/// <param name="PhoneNumber">
///     The phone number of the user
/// </param>
/// <param name="IdLocation">
///     The location identifier of the user
/// </param>
public record UserResponse(
    [property: JsonPropertyName("id_user")] int IdUser,
    string Name,
    [property: JsonPropertyName("last_name")] string LastName,
    string Dni,
    [property: JsonPropertyName("phone_number")] string PhoneNumber,
    [property: JsonPropertyName("id_location")] int IdLocation
);