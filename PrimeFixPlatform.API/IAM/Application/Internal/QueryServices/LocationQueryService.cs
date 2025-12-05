using PrimeFixPlatform.API.IAM.Domain.Model.Aggregates;
using PrimeFixPlatform.API.IAM.Domain.Model.Queries;
using PrimeFixPlatform.API.IAM.Domain.Repositories;
using PrimeFixPlatform.API.IAM.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.IAM.Application.Internal.QueryServices;

/// <summary>
///     Query service for managing Location entities.
/// </summary>
/// <param name="locationRepository">
///     The location repository.
/// </param>
public class LocationQueryService(ILocationRepository locationRepository)
: ILocationQueryService
{
    /// <summary>
    ///     Handles the retrieval of all locations.
    /// </summary>
    /// <param name="query">
    ///     The query to get all locations.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of all Location entities.
    /// </returns>
    public async Task<IEnumerable<Location>> Handle(GetAllLocationsQuery query)
    {
        return await locationRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the retrieval of a location by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to get a location by its ID.
    /// </param>
    /// <returns>
    ///     The Location entity if found; otherwise, throws NotFoundIdException.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a location with the specified ID was not found.
    /// </exception>
    public async Task<Location?> Handle(GetLocationByIdQuery query)
    {
        return await locationRepository.FindByIdAsync(query.LocationId)
            ?? throw new NotFoundIdException("Location with the id " + query.LocationId + " was not found.");
    }
}