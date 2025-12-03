namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

/// <summary>
///     Get diagnostic by expected visit
/// </summary>
/// <param name="ExpectedVisitId">
///     The id of the expected visit
/// </param>
public record GetDiagnosticsByExpectedVisitQuery(int ExpectedVisitId);