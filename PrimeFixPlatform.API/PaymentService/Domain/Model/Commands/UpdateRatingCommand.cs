using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

/// <summary>
///     Command to update a new Rating
/// </summary>
/// <param name="IdRating">
///     The unique identifier of the rating to be updated
/// </param>
/// <param name="StarRating">
///     The star rating of the rating to be updated
/// </param>
/// <param name="Comment">
///     The comment of the rating to be updated
/// </param>
/// <param name="IdAutoRepair">
///     The unique identifier of the auto repair performing the update
/// </param>
/// <param name="IdUserAccount">
///     The unique identifier of the user account performing the update
/// </param>
public record UpdateRatingCommand(string IdRating, int StarRating, string Comment, 
    IdAutoRepair IdAutoRepair, IdUserAccount IdUserAccount);
