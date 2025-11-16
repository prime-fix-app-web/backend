namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

/// <summary>
///     Command to delete a rating
/// </summary>
/// <param name="IdRating">
///     The unique identifier of the rating to be deleted
/// </param>
public record DeleteRatingCommand(string IdRating);