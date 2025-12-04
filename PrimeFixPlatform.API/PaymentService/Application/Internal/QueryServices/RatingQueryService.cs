using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.PaymentService.Application.Internal.QueryServices;

/// <summary>
///     Query service for managing Rating entities
/// </summary>
/// <param name="ratingRepository"></param>
public class RatingQueryService(IRatingRepository ratingRepository)
: IRatingQueryService
{
    /// <summary>
    ///     Handles the retrieval of all ratings.
    /// </summary>
    /// <param name="query">
    ///     The query to get all ratings.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of all Rating entities.
    /// </returns>
    public async Task<IEnumerable<Rating>> Handle(GetAllRatingsQuery query)
    {
        return await ratingRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the retrieval of a rating by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to get a rating by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the Rating entity if found; otherwise, throws NotFoundIdException.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a rating with the specified ID was not found.
    /// </exception>
    public async Task<Rating?> Handle(GetRatingByIdQuery query)
    {
        return await ratingRepository.FindByIdAsync(query.IdRating)
            ?? throw new NotFoundIdException("Rating with the id " + query.IdRating + " was not found");
    }

    /// <summary>
    ///     Handles the retrieval of a rating by the autorepair ID
    /// </summary>
    /// <param name="query">
    ///     The query to get a rating by the autorepair ID
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the Rating entity if found.
    /// </returns>
    public async Task<IEnumerable<Rating>> Handle(GetRatingByIdAutoRepairQuery query)
    {
        return await ratingRepository.FindByIdAutoRepair(query.IdAutoRepair);
    }
}