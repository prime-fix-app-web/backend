namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
/// Resource that represents a service offer exposed through the REST API.
/// </summary>
/// <param name="ServiceOfferId">
/// Identifier of the service offer.
/// </param>
/// <param name="ServiceId">
/// Identifier of the associated service.
/// </param>
/// <param name="ServiceName">
/// Name of the service associated with this offer.
/// </param>
/// <param name="Price">
/// Price assigned to the service offer.
/// </param>
public record ServiceOfferResource(
    int ServiceOfferId,
    int ServiceId,
    string ServiceName,
    decimal Price
    );