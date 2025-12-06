namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;

/// <summary>
///     Query to check if a vehicle exists by its ID
/// </summary>
/// <param name="VehicleId">
///     The unique identifier of the vehicle to check for existence.
/// </param>
public record ExistsVehicleByIdQuery(int VehicleId);