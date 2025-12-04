namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to delete a vehicle.
/// </summary>
/// <param name="VehicleId">
///     The unique identifier of the vehicle to be deleted.
/// </param>
public record DeleteVehicleCommand(int VehicleId);