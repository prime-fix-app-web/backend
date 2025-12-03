using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record UpdateDiagnosticRequest(
    
    [property:JsonPropertyName("diagnosisId")]
    [Required]
    int DiagnosisId,
    
    [property: JsonPropertyName("price")]
    [Required]
    float Price,
    
    [property: JsonPropertyName("vehicleId")]
    [Required]
    VehicleId VehicleId,
    
    [property: JsonPropertyName("diagnosis")]
    [MaxLength(100)]
    [Required]
    string Diagnosis,
    
    [property: JsonPropertyName("expectedVisitId")]
    [Required]
    int ExpectedVisitId
    
    );