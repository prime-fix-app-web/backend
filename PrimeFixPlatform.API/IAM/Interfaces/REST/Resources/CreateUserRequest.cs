using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Request to create a user
/// </summary>
/// <param name="Name">
///     The name of the user to be created
/// </param>
/// <param name="LastName">
///     The last name of the user to be created
/// </param>
/// <param name="Dni">
///     The DNI of the user to be created
/// </param>
/// <param name="PhoneNumber">
///     The phone number of the user to be created
/// </param>
/// <param name="LocationId">
///     The location identifier associated with the user to be created
/// </param>
public record CreateUserRequest(
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string Name,

    [property: JsonPropertyName("last_name")]
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string LastName,

    [Required]
    [StringLength(8, MinimumLength = 8)]
    string Dni,

    [property: JsonPropertyName("phone_number")]
    [Required]
    [StringLength(15, MinimumLength = 7)]
    string PhoneNumber,

    [property: JsonPropertyName("location_id")]
    [Required]
    int LocationId);