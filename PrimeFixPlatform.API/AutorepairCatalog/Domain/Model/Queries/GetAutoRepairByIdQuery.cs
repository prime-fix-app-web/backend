namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;

/// <summary>
///     Query to get an Auto Repair by its ID
/// </summary>
/// <param name="AutoRepairId">
///     The ID of the Auto Repair to retrieve
/// </param>
public record GetAutoRepairByIdQuery(int AutoRepairId);