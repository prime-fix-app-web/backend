using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing Vehicle entities.
/// </summary>
public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    /// <summary>
    ///     Checks if a vehicle exists by its unique identifier.
    /// </summary>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a vehicle with the specified ID exists.
    /// </returns>
    Task<bool> ExistsByIdVehicle(int vehicleId);
    
    /// <summary>
    ///     Checks if a vehicle exists by its vehicle plate.
    /// </summary>
    /// <param name="vehiclePlate">
    ///     The vehicle plate to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a vehicle with the specified vehicle plate exists.
    /// </returns>
    Task<bool> ExistsByVehiclePlate(string vehiclePlate);
    
    /// <summary>
    ///     Checks if a vehicle exists by its vehicle plate, excluding a specific vehicle by its ID.
    /// </summary>
    /// <param name="vehiclePlate">
    ///     The vehicle plate to check.
    /// </param>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a vehicle with the specified vehicle plate exists,
    ///     excluding the vehicle with the specified ID.
    /// </returns>
    Task<bool> ExistsByVehiclePlateAndIdVehicleIsNot(string vehiclePlate, int vehicleId);
    
    /// <summary>
    ///     Finds vehicles by their maintenance status.
    /// </summary>
    /// <param name="maintenanceStatus">
    ///     The maintenance status to filter vehicles by.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of vehicles with the specified maintenance status.
    /// </returns>
    Task<IEnumerable<Vehicle>> FindByMaintenanceStatus(EMaintenanceStatus maintenanceStatus);
}