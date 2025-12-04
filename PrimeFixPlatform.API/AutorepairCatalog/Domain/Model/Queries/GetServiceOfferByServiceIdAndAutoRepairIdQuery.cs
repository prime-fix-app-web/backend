namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;

/// <summary>
/// Query used to retrieve a service offer by service identifier and auto repair identifier.
/// </summary>
/// <param name="ServiceId">
/// Identifier of the service associated with the service offer.
/// </param>
/// <param name="AutoRepairId">
/// Identifier of the auto repair shop that provides the service.
/// </param>
public record GetServiceOfferByServiceIdAndAutoRepairIdQuery(int ServiceId, int AutoRepairId);