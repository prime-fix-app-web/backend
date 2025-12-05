using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;

namespace PrimeFixPlatform.API.PaymentService.Domain.Services;

/// <summary>
///     Represents a repository interface for handling rating queries.
/// </summary>
public interface IRatingQueryService
{
    /// <summary>
    ///     Handles the GetAllRatingsQuery to retrieve all ratings.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving ratings.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable of ratings.
    /// </returns>
    Task<IEnumerable<Rating>> Handle(GetAllRatingsQuery query);
    
    /// <summary>
    ///     Handles the GetRatingByIdQuery to retrieve a rating by its ID.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the rating to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the rating if found; otherwise, null.
    /// </returns>
    Task<Rating?> Handle(GetRatingByIdQuery query);
    
    /// <summary>
    ///     Handles the GetAllRatingsQuery to retrieve all ratings.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the auto repair related to de payment to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable of ratings.
    /// </returns>
    Task<IEnumerable<Rating>> Handle(GetRatingByIdAutoRepairQuery query);
}