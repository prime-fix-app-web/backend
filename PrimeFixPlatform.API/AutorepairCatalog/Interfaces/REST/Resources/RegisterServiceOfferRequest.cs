using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
/// Request resource used to register a new service offer into an auto repair service catalog.
/// </summary>
/// <param name="ServiceId">
/// Identifier of the service that will be offered.
/// This field is required.
/// </param>
/// <param name="Price">
/// Price assigned to the service offer.
/// This field is required.
/// </param>
/// <param name="DurationHours">
/// Estimated duration of the service in hours.
/// </param>
/// <param name="IsActive">
/// Indicates whether the service offer should be active after creation.
/// </param>
public record RegisterServiceOfferRequest(
    [property: JsonPropertyName("service_id")]
    [Required]
    int ServiceId,
    
    [property: JsonPropertyName("price")]
    [Required]
    decimal Price,
    
    [property: JsonPropertyName("duration_hours")]
    int DurationHours,
    
    [property: JsonPropertyName("is_active")]
    bool IsActive
    );