namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;

/// <summary>
///     Query to check if an Auto Repair exists by its identifier.
/// </summary>
/// <param name="AutoRepairId">
///     The identifier of the Auto Repair to check.
/// </param>
public record ExistsAutoRepairByIdQuery(int AutoRepairId);