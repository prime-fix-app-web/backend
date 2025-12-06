using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.QueryServices;

/// <summary>
///     Query service for managing Vehicle entities.
/// </summary>
/// <param name="vehicleRepository">
///     The vehicle repository.
/// </param>
public class VehicleQueryService(IVehicleRepository vehicleRepository)
: IVehicleQueryService
{
    /// <summary>
    ///     Handles the retrieval of all vehicles.
    /// </summary>
    /// <param name="query">
    ///     The query to get all vehicles.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of all Vehicle entities.
    /// </returns>
    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query)
    {
        return await vehicleRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the retrieval of a vehicle by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to get a vehicle by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the Vehicle entity if found; otherwise, throws NotFoundIdException.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a vehicle with the specified ID was not found.
    /// </exception>
    public async Task<Vehicle?> Handle(GetVehicleByIdQuery query)
    {
        return await vehicleRepository.FindByIdAsync(query.VehicleId)
            ?? throw new NotFoundIdException("Vehicle with the id " + query.VehicleId + " was not found.");
    }

    /// <summary>
    ///     Handles the retrieval of vehicles by their maintenance status.
    /// </summary>
    /// <param name="query">
    ///     The query to get vehicles by maintenance status.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of Vehicle entities with the specified maintenance status.
    /// </returns>
    public async Task<IEnumerable<Vehicle>> Handle(GetVehicleByMaintenanceStatusQuery query)
    {
        return await vehicleRepository.FindByMaintenanceStatus(query.MaintenanceStatus);
    }

    /// <summary>
    ///     Handles the check for the existence of a vehicle by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to check if a vehicle exists by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean value indicating whether the vehicle exists.  
    /// </returns>
    public async Task<bool> Handle(ExistsVehicleByIdQuery query)
    {
        return await vehicleRepository.ExistsByVehicleId(query.VehicleId);
    }
}