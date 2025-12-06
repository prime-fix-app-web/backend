using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///     Command to create a new ExpectedVisit
/// </summary>
/// <param name="VisitId"> The visitID of the Expected Visit</param>
/// <param name="VehicleId">
///     The vehicle ID associated with the Expected Visit
/// </param>
public record CreateExpectedVisitCommand(int VisitId, int VehicleId);