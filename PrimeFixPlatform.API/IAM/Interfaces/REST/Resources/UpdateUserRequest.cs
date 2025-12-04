using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///    Request to update a user
/// </summary>
/// <param name="Name">
///     The name of the user to be updated
/// </param>
/// <param name="LastName">
///     The last name of the user to be updated
/// </param>
/// <param name="Dni">
///     The DNI of the user to be updated
/// </param>
/// <param name="PhoneNumber">
///     The phone number of the user to be updated
/// </param>
/// <param name="LocationId">
///     The location identifier associated with the user to be updated
/// </param>
public record UpdateUserRequest(
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

    [property: JsonPropertyName("id_location")]
    [Required]
    int LocationId
);