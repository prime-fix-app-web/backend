namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;

/// <summary>
///     Query to get a vehicle by its identifier.
/// </summary>
/// <param name="IdVehicle">
///     The unique identifier of the vehicle to be retrieved.
/// </param>
public record GetVehicleByIdQuery(string IdVehicle);