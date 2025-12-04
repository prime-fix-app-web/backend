namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
///     Command to update an auto repair's details.
/// </summary>
/// <param name="AutoRepairId">
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
/// <param name="UserAccountId">
///     The unique identifier of the user account associated with the auto repair.
/// </param>
public record UpdateAutoRepairCommand(int AutoRepairId, string Ruc, string ContactEmail, int TechniciansCount, int UserAccountId);