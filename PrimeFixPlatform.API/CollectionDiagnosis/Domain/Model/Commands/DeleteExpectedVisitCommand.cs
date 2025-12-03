namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///     Command to delete a ExpectedVisit
/// </summary>
/// <param name="ExpectedVisitId">
///     The ID of the expectedVisit to be deleted
/// </param>
public record DeleteExpectedVisitCommand(int ExpectedVisitId);