namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
/// Command used to remove an existing service offer from an auto repair service catalog.
/// </summary>
/// <param name="ServiceId">
/// Identifier of the service to be removed from the catalog.
/// </param>
/// <param name="AutoRepairId">
/// Identifier of the auto repair shop from which the service offer will be removed.
/// </param>
public record DeleteServiceToAutoRepairServiceCommand(int ServiceId, int AutoRepairId);