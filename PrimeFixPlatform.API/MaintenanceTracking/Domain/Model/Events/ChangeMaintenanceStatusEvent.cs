using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Events;

/// <summary>
///     Event to change the maintenance status of a vehicle
/// </summary>
/// <param name="VehicleId">
///     The ID of the vehicle whose maintenance status is to be changed
/// </param>
/// <param name="MaintenanceStatus">
///     The new maintenance status to be set
/// </param>
public sealed record ChangeMaintenanceStatusEvent(int VehicleId, EMaintenanceStatus MaintenanceStatus) : IEvent;