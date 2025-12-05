using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
/// Request resource used to update an existing service in the auto repair catalog.
/// </summary>
/// <param name="Name">
/// Updated name of the service.
/// This field is required.
/// </param>
/// <param name="Description">
/// Updated description of the service.
/// This field is required.
/// </param>
public record UpdateServiceRequest(
    
    [property:JsonPropertyName("Name")]
    [Required]
    string Name,
    
    [property:JsonPropertyName("description")]
    [Required]
    string Description
    );