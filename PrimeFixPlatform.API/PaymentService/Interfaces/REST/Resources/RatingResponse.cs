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
/// <param name="IdAutoRepair">
///     The identifier of the auto repair associated with the rating 
/// </param>
/// <param name="IdUserAccount">
///     The identifier of the user associated with the rating 
/// </param>
public record RatingResponse(
    [property: JsonPropertyName("id_rating")] string IdRating,
    [property: JsonPropertyName("star_rating")] int StarRating,
    string Comment,
    [property: JsonPropertyName("id_auto_repair")] string IdAutoRepair,
    [property: JsonPropertyName("id_user_account")] string IdUserAccount
    );