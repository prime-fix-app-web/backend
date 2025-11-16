using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;

/// <summary>
///     Request to create a rating
/// </summary>
/// <param name="IdRating">
///     The unique identifier of the rating to be created
/// </param>
/// <param name="StarRating">
///     The star rating of the rating to be created
/// </param>
/// <param name="Comment">
///     The comment of the rating to be created
/// </param>
/// <param name="IdAutoRepair">
///     The identifier of the auto repair associated with the rating to be created
/// </param>
/// <param name="IdUserAccount">
///     The identifier of the user associated with the rating to be created
/// </param>
public record CreateRatingRequest(
    [property: JsonPropertyName("id_rating")]
    [Required]
    [MinLength(1)]
    string IdRating,
    
    [property: JsonPropertyName("star_rating")]
    [Required]
    int StarRating,
    
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    string Comment,
    
    [property: JsonPropertyName("id_auto_repair")]
    [Required]
    [MinLength(1)]
    string IdAutoRepair,
    
    [property: JsonPropertyName("id_user_account")]
    [Required]
    [MinLength(1)]
    string IdUserAccount
    );