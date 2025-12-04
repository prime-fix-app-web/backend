namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

/// <summary>
///     Command to create a new Rating
/// </summary>
/// <param name="StarRating">
///     The star rating of the rating to be created
/// </param>
/// <param name="Comment">
///     The commento of the rating to be created
/// </param>
/// <param name="AutoRepairId">
///     The unique identifier of the auto repair with the rating to be created
/// </param>
/// <param name="UserAccountId">
///     The unique identifier of the user associated with the rating to be created
/// </param>
public record CreateRatingCommand( int StarRating, string Comment, 
    int AutoRepairId, int UserAccountId);