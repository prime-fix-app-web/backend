using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;

/// <summary>
///     Query to get vehicles by their maintenance status.
/// </summary>
/// <param name="MaintenanceStatus">
///     The maintenance status to filter vehicles by.
/// </param>
public record GetVehicleByMaintenanceStatusQuery(EMaintenanceStatus MaintenanceStatus);