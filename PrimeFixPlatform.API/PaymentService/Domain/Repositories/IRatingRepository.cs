using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.PaymentService.Domain.Repositories;

public interface IRatingRepository: IBaseRepository<Rating>
{
    /// <summary>
    ///     Checks if a rating exists by its unique identifier
    /// </summary>
    /// <param name="ratingId">
    ///     The unique identifier of the rating
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a rating with the specified ID exists. 
    /// </returns>
    Task<bool> ExistsByIdRating(int ratingId);
    
    /// <summary>
    ///     Checks if a rating exists by an auto repair associated.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The unique identifier of the auto repair to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a rating with the specified auto repair exists.
    /// </returns>
    Task<bool> ExistsByIdAutoRepair(int autoRepairId);
    
    /// <summary>
    ///     Checks if a rating exists by an auto repair associated, excluding a specific rating by its ID.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The unique identifier of the auto repair to check.
    /// </param>
    /// <param name="ratingId">
    ///     The unique identifier of the rating to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a rating with the specified auto repair associated exists,
    ///     excluding the rating with the specified ID.
    /// </returns>
    Task<bool> ExistsByIdAutoRepairAndIdRatingIsNot(int autoRepairId, int ratingId);
    
    /// <summary>
    ///     Finds ratings by the auto repair associated.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The unique identifier of the auto repair to filter ratings by.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of ratings with the specified auto repair associated.
    /// </returns>
    Task<IEnumerable<Rating>> FindByIdAutoRepair(int autoRepairId);
    
}