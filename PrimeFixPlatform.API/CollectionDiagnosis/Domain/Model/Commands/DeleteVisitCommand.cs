namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///     Command to delete a visit
/// </summary>
/// <param name="VisitId">
///     The ID of the visit to be deleted
/// </param>
public record DeleteVisitCommand(int VisitId);