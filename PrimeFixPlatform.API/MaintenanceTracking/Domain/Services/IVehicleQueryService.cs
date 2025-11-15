using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;

/// <summary>
///     Represents the contract for vehicle query services.
/// </summary>
public interface IVehicleQueryService
{
    /// <summary>
    ///     Handles the retrieval of all vehicles.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving all vehicles.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable collection of Vehicle entities.
    /// </returns>
    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query);
    
    /// <summary>
    ///     Handles the retrieval of a vehicle by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the unique identifier of the vehicle to be retrieved.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the Vehicle entity if found; otherwise, null.
    /// </returns>
    Task<Vehicle?> Handle(GetVehicleByIdQuery query);
    
    /// <summary>
    ///     Handles the retrieval of vehicles by their maintenance status.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the maintenance status criteria.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable collection of Vehicle entities that match the maintenance status.
    /// </returns>
    Task<IEnumerable<Vehicle>> Handle(GetVehicleByMaintenanceStatusQuery query);
}