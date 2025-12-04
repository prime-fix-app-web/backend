namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

/// <summary>
///     Command to update a new Rating
/// </summary>
/// <param name="RatingId">
///     The unique identifier of the rating to be updated
/// </param>
/// <param name="StarRating">
///     The star rating of the rating to be updated
/// </param>
/// <param name="Comment">
///     The comment of the rating to be updated
/// </param>
/// <param name="AutoRepairId">
///     The unique identifier of the auto repair performing the update
/// </param>
/// <param name="UserAccountId">
///     The unique identifier of the user account performing the update
/// </param>
public record UpdateRatingCommand(int RatingId, int StarRating, string Comment, 
    int AutoRepairId, int UserAccountId);
