namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

/// <summary>
///     Query to retrieve a visit ID
/// </summary>
/// <param name="VisitId">
///     The visit ID
/// </param>
public record GetVisitByIdQuery(int  VisitId);