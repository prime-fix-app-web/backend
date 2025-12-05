using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;

/// <summary>
///     Response representing a rating
/// </summary>
/// <param name="IdRating">
///     The unique identifier of the rating 
/// </param>
/// <param name="StarRating">
///     The star rating of the rating 
/// </param>
/// <param name="Comment">
///     The comment of the rating 
/// </param>
/// <param name="AutoRepairId">
///     The identifier of the auto repair associated with the rating 
/// </param>
/// <param name="UserAccountId">
///     The identifier of the user associated with the rating 
/// </param>
public record RatingResponse(
    int Id,
    [property: JsonPropertyName("star_rating")] int StarRating,
    string Comment,
    [property: JsonPropertyName("auto_repair_id")] int AutoRepairId,
    [property: JsonPropertyName("user_account_id")] int UserAccountId
    );