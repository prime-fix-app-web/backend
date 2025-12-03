namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;

/// <summary>
///     Query to get an Auto Repair by its ID
/// </summary>
/// <param name="IdAutoRepair">
///     The ID of the Auto Repair to retrieve
/// </param>
public record GetAutoRepairByIdQuery(int IdAutoRepair);