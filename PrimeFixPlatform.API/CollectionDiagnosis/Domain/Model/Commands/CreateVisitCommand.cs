using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///     Command to create a new Visit
/// </summary>
/// <param name="failure">
///     The description of the vehicle fault
/// </param>
/// <param name="vehicleId">
///     The ID of the vehicle designated for the visit 
/// </param>
/// <param name="timeVisit">
///     The date assigned for the visit
/// </param>
/// <param name="autoRepairId">
///     The ID of the auto repair designated for the visit
/// </param>
/// <param name="serviceId">
///     The ID of the service designated for the visit
/// </param>
public record CreateVisitCommand(string Failure, int VehicleId, string TimeVisit, int AutoRepairId, int ServiceId);