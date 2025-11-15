namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
///     Command to create a new Auto Repair entity.
/// </summary>
/// <param name="IdAutoRepair">
///     The unique identifier for the Auto Repair.
/// </param>
/// <param name="Ruc">
///     The Single Taxpayer Registry number of the Auto Repair.
/// </param>
/// <param name="ContactEmail">
///     The contact email address for the Auto Repair.
/// </param>
/// <param name="TechniciansCount">
///     The number of technicians available at the Auto Repair.
/// </param>
/// <param name="IdUserAccount">
///     The identifier of the user account associated with the Auto Repair.
/// </param>
public record CreateAutoRepairCommand(string IdAutoRepair, string Ruc, string ContactEmail, int TechniciansCount, string IdUserAccount);