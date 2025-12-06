namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;

/// <summary>
///     Represents the various statuses that a maintenance request can have.
/// </summary>
public enum EMaintenanceStatus
{
    NotBeingServiced = 0,
    Waiting = 1,
    InDiagnosis = 2,
    InRepair = 3,
    Testing = 4,
    ReadyForPickup = 5,
    Collected = 6
}

