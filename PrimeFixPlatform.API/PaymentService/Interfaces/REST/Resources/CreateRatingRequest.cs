using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;

/// <summary>
///     Request to create a rating
/// </summary>
/// <param name="StarRating">
///     The star rating of the rating to be created
/// </param>
/// <param name="Comment">
///     The comment of the rating to be created
/// </param>
/// <param name="AutoRepairId">
///     The identifier of the auto repair associated with the rating to be created
/// </param>
/// <param name="UserIdAccountId">
///     The identifier of the user associated with the rating to be created
/// </param>
public record CreateRatingRequest(

    
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
    int UserIdAccountId
    );