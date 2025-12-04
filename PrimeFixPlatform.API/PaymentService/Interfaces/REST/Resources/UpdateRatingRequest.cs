using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;

/// <summary>
///     Request to update a rating
/// </summary>
/// <param name="StarRating">
///     The star rating of the rating to be updated
/// </param>
/// <param name="Comment">
///     The comment of the rating to be updated
/// </param>
/// <param name="AutoRepairId">
///     The identifier of the auto repair associated with the rating to be updated
/// </param>
/// <param name="UserAccountId">
///     The identifier of the user associated with the rating to be updated
/// </param>
public record UpdateRatingRequest(
    [property: JsonPropertyName("star_rating")]
    [Required]
    int StarRating,
    
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    string Comment,
    
    [property: JsonPropertyName("auto_repair_id")]
    [Required]
    int AutoRepairId,
    
    [property: JsonPropertyName("user_account_id")]
    [Required]
    int UserAccountId
    );