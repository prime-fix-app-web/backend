using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.AutorepairCatalog.Infrastructure.Persistence.EFC.Repositories;

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
    /// <param name="idLocation">
    ///     The unique identifier of the Location entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a Location entity with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByIdLocation(int idLocation)
    {
        return await Context.Set<Location>().AnyAsync(location => location.IdLocation == idLocation);
    }
}