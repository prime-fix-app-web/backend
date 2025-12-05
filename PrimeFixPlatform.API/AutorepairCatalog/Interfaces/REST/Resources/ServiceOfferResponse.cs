using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

public record ServiceOfferResponse(
    [property: JsonPropertyName("service_id")] int ServiceId,
    [property: JsonPropertyName("service_name")] string ServiceName,
    [property: JsonPropertyName("price")] decimal Price,
    [property: JsonPropertyName("duration_hours")] int DurationHours,
    [property: JsonPropertyName("is_active")] bool IsActive
    );