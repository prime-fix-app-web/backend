using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record UpdateDiagnosticRequest(
    
    [property:JsonPropertyName("diagnosisId")]
    [Required]
    string DiagnosisId,
    
    [property: JsonPropertyName("price")]
    [Required]
    float Price,
    
    [property: JsonPropertyName("vehicleId")]
    [Required]
    string VehicleId,
    
    [property: JsonPropertyName("diagnosis")]
    [MaxLength(100)]
    [Required]
    string Diagnosis,
    
    [property: JsonPropertyName("expectedVisitId")]
    [Required]
    [MaxLength(50)]
    string ExpectedVisitId
    
    );