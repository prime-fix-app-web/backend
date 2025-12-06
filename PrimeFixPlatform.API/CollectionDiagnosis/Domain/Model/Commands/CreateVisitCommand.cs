namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///     Command to create a new Visit
/// </summary>
/// <param name="Failure">
///     The description of the vehicle fault
/// </param>
/// <param name="VehicleId">
///     The ID of the vehicle designated for the visit 
/// </param>
/// <param name="TimeVisit">
///     The date assigned for the visit
/// </param>
/// <param name="AutoRepairId">
///     The ID of the auto repair designated for the visit
/// </param>
/// <param name="ServiceId">
///     The ID of the service designated for the visit
/// </param>
public record CreateVisitCommand(string Failure, int VehicleId, DateTime TimeVisit, int AutoRepairId, int ServiceId);