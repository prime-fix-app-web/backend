using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record CreateDiagnosticRequest(
    
    [property:JsonPropertyName("price")]
    [Required]
    float Price,
    
    [property:JsonPropertyName("vehicleId")]
    [Required]
    int VehicleId,
    
    [property:JsonPropertyName("diagnosis")]
    [Required]
    [MaxLength(100)]
    string Diagnosis,
    
    [property:JsonPropertyName("expectedVisitId")]
    int ExpectedVisitId
    );