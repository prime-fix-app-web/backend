namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

/// <summary>
///     Query to retrieve a visit by Service ID
/// </summary>
/// <param name="ServiceId">
///     The service ID
/// </param>
public record GetVisitByServiceIdQuery(int ServiceId);