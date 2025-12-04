namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
/// Command used to register a new service offer into an auto repair service catalog.
/// </summary>
/// <param name="AutoRepairId">
/// Identifier of the auto repair shop where the service will be offered.
/// </param>
/// <param name="ServiceId">
/// Identifier of the service to be added to the catalog.
/// </param>
/// <param name="Price">
/// Price assigned to the service offer.
/// </param>
/// <param name="DurationHours">
/// Estimated duration of the service in hours.
/// </param>
/// <param name="IsActive">
/// Indicates whether the service offer should be active after creation.
/// </param>
public record AddServiceToAutoRepairServiceCatalogCommand(int AutoRepairId, int ServiceId, decimal Price, int DurationHours, bool IsActive);