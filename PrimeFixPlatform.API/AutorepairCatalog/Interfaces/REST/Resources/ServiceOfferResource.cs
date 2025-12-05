using System.Text.Json.Serialization;

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
    [property: JsonPropertyName("service_id")] int ServiceId,
    [property: JsonPropertyName("price")] decimal Price,
    [property: JsonPropertyName("duration_hours")] int DurationHours,
    [property: JsonPropertyName("is_active")] bool IsActive
    );