namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

/// <summary>
///     Get diagnostic by id
/// </summary>
/// <param name="DiagnosticId">
///     The id of the diagnostic
/// </param>
public record GetDiagnosticByIdQuery(string DiagnosticId);