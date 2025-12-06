namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

/// <summary>
///     Query to get an Expected Visit by its ID
/// </summary>
/// <param name="ExpectedVisitId">
///     The ID of the Expected Visit to retrieve
/// </param>
public record GetExpectedVisitByIdQuery(int ExpectedVisitId);