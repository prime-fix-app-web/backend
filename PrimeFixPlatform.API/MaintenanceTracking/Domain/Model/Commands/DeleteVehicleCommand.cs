namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to delete a vehicle.
/// </summary>
/// <param name="IdVehicle">
///     The unique identifier of the vehicle to be deleted.
/// </param>
public record DeleteVehicleCommand(string IdVehicle);