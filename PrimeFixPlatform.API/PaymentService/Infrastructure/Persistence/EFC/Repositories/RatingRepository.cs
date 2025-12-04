using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.PaymentService.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Rating entities.
/// </summary>
/// <param name="context"></param>
public class RatingRepository(AppDbContext context)
: BaseRepository<Rating>(context), IRatingRepository
{
    /// <summary>
    ///     Checks if a rating exists by its unique identifier
    /// </summary>
    /// <param name="idRating">
    ///     The unique identifier of the rating
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a rating with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByIdRating(int idRating)
    {
        return await Context.Set<Rating>().AnyAsync(rating => rating.RatingId == idRating);
    }

    /// <summary>
    ///     Checks if a rating exists by the auto repair ID.
    /// </summary>
    /// <param name="idAutoRepair">
    ///     The auto repair ID to check for existence.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a rating with the specified auto repair ID exists.
    /// </returns>
    public async Task<bool> ExistsByIdAutoRepair(int idAutoRepair)
    {
        return await Context.Set<Rating>().AnyAsync(rating => rating.UserAccountId == idAutoRepair);
    }

    /// <summary>
    ///     Checks if a vehicle exists by the auto repair ID, excluding a specific rating by its ID.
    /// </summary>
    /// <param name="idAutoRepair">
    ///     The auto repair ID to check for existence.
    /// </param>
    /// <param name="idRating">
    ///     The unique identifier of the rating to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a rating with the specified auto repair ID exists,
    ///     excluding the rating with the specified ID.
    /// </returns>
    public async Task<bool> ExistsByIdAutoRepairAndIdRatingIsNot(int idAutoRepair, int idRating)
    {
        return await Context.Set<Rating>().AnyAsync(rating => 
            rating.AutoRepairId == idAutoRepair && rating.RatingId != idRating);
    }
    
    
    /// <summary>
    ///     Finds ratings by the auto repair ID.
    /// </summary>
    /// <param name="idAutoRepair">
    ///     The auto repair ID to filter ratings by.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of ratings with the specified auto repair ID.
    /// </returns>
    public async Task<IEnumerable<Rating>> FindByIdAutoRepair(int idAutoRepair)
    {
        return await Context.Set<Rating>()
            .Where(rating => rating.AutoRepairId == idAutoRepair)
            .ToListAsync();
    }
}