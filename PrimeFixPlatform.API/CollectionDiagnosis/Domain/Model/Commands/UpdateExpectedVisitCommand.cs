using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///     Command to update an existing expected visit
/// </summary>
/// <param name="ExpectedVisitId">
///     The ID of the Expected Visit to be updated
/// </param>
/// <param name="StateVisit">
///     The state visit of the Expected Visit
/// </param>
/// <param name="VisitId">
///     The visitID of the Expected Visit
/// </param>
/// <param name="IsScheduled">
///     The state of the expected visit
/// </param>
/// <param name="VehicleId">
///     The vehicle ID associated with the Expected Visit
/// </param>
public record UpdateExpectedVisitCommand(int ExpectedVisitId, EStateVisit StateVisit, int VisitId, bool IsScheduled, int VehicleId);