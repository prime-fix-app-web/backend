using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record CreateDiagnosticRequest(
    [Required]
    float Price,
    
    [property:JsonPropertyName("vehicle_id")]
    [Required]
    int VehicleId,
    
    [Required]
    [MaxLength(100)]
    string Diagnosis,
    
    [Required]
    [property:JsonPropertyName("expected_visit_id")]
    int ExpectedVisitId);