using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record CreateDiagnosticRequest(
    
    [property:JsonPropertyName("price")]
    [Required]
    float Price,
    
    [property:JsonPropertyName("vehicleId")]
    [Required]
    [MinLength(1)]
    string VehicleId,
    
    [property:JsonPropertyName("diagnosis")]
    [Required]
    [MaxLength(100)]
    string Diagnosis,
    
    [property:JsonPropertyName("expectedVisitId")]
    [MinLength(1)]
    string ExpectedVisitId
    );