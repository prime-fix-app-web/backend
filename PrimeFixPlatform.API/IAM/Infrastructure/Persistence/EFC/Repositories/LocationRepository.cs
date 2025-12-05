using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.IAM.Domain.Model.Aggregates;
using PrimeFixPlatform.API.IAM.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.IAM.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Location entities.
/// </summary>
/// <param name="context">
///     The database context used for data access.
/// </param>
public class LocationRepository(AppDbContext context)
: BaseRepository<Location>(context), ILocationRepository
{
    /// <summary>
    ///     Checks if a Location entity exists by its unique identifier.
    /// </summary>
    /// <param name="locationId">
    ///     The unique identifier of the Location entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a Location entity with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByLocationId(int locationId)
    {
        return await Context.Set<Location>().AnyAsync(location => location.Id == locationId);
    }
}