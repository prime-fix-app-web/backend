using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///     Command to create a new ExpectedVisit
/// </summary>
/// <param name="StateVisit"> The state visit of the Expected Visit</param>
/// <param name="VisitId"> The visitID of the Expected Visit</param>
/// <param name="IsScheduled">The state of the expected visit</param>
public record CreateExpectedVisitCommand(Status StateVisit, int VisitId, bool IsScheduled);