namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

/// <summary>
///     Command to create a new Rating
/// </summary>
/// <param name="IdRating">
///     The unique identifier for the rating to be created
/// </param>
/// <param name="StarRating">
///     The star rating of the rating to be created
/// </param>
/// <param name="Comment">
///     The commento of the rating to be created
/// </param>
/// <param name="IdAutoRepair">
///     The unique identifier of the auto repair with the rating to be created
/// </param>
/// <param name="IdUserAccount">
///     The unique identifier of the user associated with the rating to be created
/// </param>
public record CreateRatingCommand(string IdRating, int StarRating, string Comment, 
    string IdAutoRepair, string IdUserAccount);