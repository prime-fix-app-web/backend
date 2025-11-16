using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record UpdateServiceRequest(
    
    [property:JsonPropertyName("serviceId")]
    [Required]
    string ServiceId,
    
    [property:JsonPropertyName("Name")]
    [Required]
    string Name,
    
    [property:JsonPropertyName("description")]
    [Required]
    string Description
    );