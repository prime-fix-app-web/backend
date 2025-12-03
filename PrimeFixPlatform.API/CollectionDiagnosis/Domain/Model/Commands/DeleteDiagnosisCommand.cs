namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
/// <summary>
///     Command to delete a Diagnosis
/// </summary>
/// <param name="DiagnosisId">
///     The ID of the diagnosis to be deleted
/// </param>
public record DeleteDiagnosisCommand(int DiagnosisId);