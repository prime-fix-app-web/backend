namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

/// <summary>
///     Query to retrieve all visits by Auto Repair ID
/// </summary>
/// <param name="AutoRepairId">
///     The auto Repair ID
/// </param>
public record GetAllVisitByAutoRepairIdQuery(string AutoRepairId);