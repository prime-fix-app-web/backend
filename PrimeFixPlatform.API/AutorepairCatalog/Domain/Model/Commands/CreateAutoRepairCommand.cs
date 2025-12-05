namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
///     Command to create a new Auto Repair entity.
/// </summary>
/// <param name="Ruc">
///     The Single Taxpayer Registry number of the Auto Repair.
/// </param>
/// <param name="ContactEmail">
///     The contact email address for the Auto Repair.
/// </param>
/// <param name="UserAccountId">
///     The identifier of the user account associated with the Auto Repair.
/// </param>
public record CreateAutoRepairCommand( string Ruc, string ContactEmail, int UserAccountId);