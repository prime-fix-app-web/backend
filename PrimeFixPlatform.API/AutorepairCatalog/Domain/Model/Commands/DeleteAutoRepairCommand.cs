namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
///     Command to delete an existing Auto Repair entity.
/// </summary>
/// <param name="AutoRepairId">
///     The unique identifier for the Auto Repair to be deleted.
/// </param>
public record DeleteAutoRepairCommand(int AutoRepairId);