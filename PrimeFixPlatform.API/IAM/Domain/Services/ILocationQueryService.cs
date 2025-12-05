using PrimeFixPlatform.API.IAM.Domain.Model.Aggregates;
using PrimeFixPlatform.API.IAM.Domain.Model.Queries;

namespace PrimeFixPlatform.API.IAM.Domain.Services;

/// <summary>
///     Represents a repository interface for handling location queries.
/// </summary>
public interface ILocationQueryService
{
    /// <summary>
    ///     Handles the GetAllLocationsQuery to retrieve all locations.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving locations.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable of locations.
    /// </returns>
    Task<IEnumerable<Location>> Handle(GetAllLocationsQuery query);
    
    /// <summary>
    ///     Handles the GetLocationByIdQuery to retrieve a location by its ID.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the location to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the location if found; otherwise, null.
    /// </returns>
    Task<Location?> Handle(GetLocationByIdQuery query);
}