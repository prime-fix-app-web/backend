namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
///     Command to update an auto repair's details.
/// </summary>
/// <param name="IdAutoRepair">
///     The unique identifier of the auto repair to be updated.
/// </param>
/// <param name="Ruc">
///     The Single Taxpayer Registry number of the auto repair to be updated.
/// </param>
/// <param name="ContactEmail">
///     The contact email of the auto repair to be updated.
/// </param>
/// <param name="TechniciansCount">
///     The number of technicians in the auto repair to be updated.
/// </param>
/// <param name="IdUserAccount">
///     The unique identifier of the user account associated with the auto repair.
/// </param>
public record UpdateAutoRepairCommand(int IdAutoRepair, string Ruc, string ContactEmail, int TechniciansCount, int IdUserAccount);