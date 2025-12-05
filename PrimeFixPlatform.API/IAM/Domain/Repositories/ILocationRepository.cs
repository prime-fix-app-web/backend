using PrimeFixPlatform.API.IAM.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.IAM.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing Location entities.
/// </summary>
public interface ILocationRepository : IBaseRepository<Location>
{
    /// <summary>
    ///     Checks if a Location entity exists by its unique identifier.
    /// </summary>
    /// <param name="locationId">
    ///     The unique identifier of the Location entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether the Location entity exists.
    /// </returns>
    Task<bool> ExistsByLocationId(int locationId);
}