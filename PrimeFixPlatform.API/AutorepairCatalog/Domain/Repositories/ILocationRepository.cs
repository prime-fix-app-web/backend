using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing Location entities.
/// </summary>
public interface ILocationRepository : IBaseRepository<Location>
{
    /// <summary>
    ///     Checks if a Location entity exists by its unique identifier.
    /// </summary>
    /// <param name="idLocation">
    ///     The unique identifier of the Location entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether the Location entity exists.
    /// </returns>
    Task<bool> ExistsByIdLocation(string idLocation);
}
