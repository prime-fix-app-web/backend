namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;

/// <summary>
///     Query to get a rating by its identifier.
/// </summary>
/// <param name="IdRating">
///     The unique identifier of the rating to be retrieved.
/// </param>
public record GetRatingByIdQuery(string IdRating);
