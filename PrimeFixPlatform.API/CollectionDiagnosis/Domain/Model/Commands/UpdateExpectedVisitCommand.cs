using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///     Command to update an existing expected visit
/// </summary>
/// <param name="StateVisit">The state visit of the Expected Visit</param>
/// <param name="VisitId">The visitID of the Expected Visit</param>
/// <param name="IsScheduled">The state of the expected visit</param>
public record UpdateExpectedVisitCommand(int Id, Status StateVisit, int VisitId, bool IsScheduled);