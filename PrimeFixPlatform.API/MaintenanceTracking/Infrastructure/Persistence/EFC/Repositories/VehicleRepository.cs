using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.MaintenanceTracking.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Vehicle entities.
/// </summary>
/// <param name="context"></param>
public class VehicleRepository(AppDbContext context)
: BaseRepository<Vehicle>(context), IVehicleRepository
{
    /// <summary>
    ///     Checks if a vehicle exists by its unique identifier.
    /// </summary>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a vehicle with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByIdVehicle(int vehicleId)
    {
        return await Context.Set<Vehicle>().AnyAsync(vehicle => vehicle.Id == vehicleId);
    }

    /// <summary>
    ///     Checks if a vehicle exists by its vehicle plate.
    /// </summary>
    /// <param name="vehiclePlate">
    ///     The vehicle plate to check for existence.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a vehicle with the specified vehicle plate exists.
    /// </returns>
    public async Task<bool> ExistsByVehiclePlate(string vehiclePlate)
    {
        return await Context.Set<Vehicle>().AnyAsync(vehicle => vehicle.VehicleInformation.VehiclePlate == vehiclePlate);
    }

    /// <summary>
    ///     Checks if a vehicle exists by its vehicle plate, excluding a specific vehicle by its ID.
    /// </summary>
    /// <param name="vehiclePlate">
    ///     The vehicle plate to check for existence.
    /// </param>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a vehicle with the specified vehicle plate exists,
    ///     excluding the vehicle with the specified ID.
    /// </returns>
    public async Task<bool> ExistsByVehiclePlateAndIdVehicleIsNot(string vehiclePlate, int vehicleId)
    {
        return await Context.Set<Vehicle>().AnyAsync(vehicle => 
            vehicle.VehicleInformation.VehiclePlate == vehiclePlate && vehicle.Id != vehicleId);
    }

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
    public async Task<IEnumerable<Vehicle>> FindByMaintenanceStatus(EMaintenanceStatus maintenanceStatus)
    {
        return await Context.Set<Vehicle>()
            .Where(vehicle => vehicle.MaintenanceStatus == maintenanceStatus)
            .ToListAsync();
    }
}