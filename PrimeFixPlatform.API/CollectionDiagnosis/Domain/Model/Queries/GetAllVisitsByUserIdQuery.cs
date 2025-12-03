namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

/// <summary>
///     Query to retrieve all visits by User ID
/// </summary>
/// <param name="UserId">
///     The visit ID
/// </param>
public record GetAllVisitsByUserIdQuery(int UserId);