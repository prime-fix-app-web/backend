using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record UpdateDiagnosticRequest(
    
    [Required]
    float Price,
    
    [property: JsonPropertyName("vehicle_id")]
    [Required]
    VehicleId VehicleId,
    
    [MaxLength(100)]
    [Required]
    string Diagnosis,
    
    [property: JsonPropertyName("expected_visit_id")]
    [Required]
    int ExpectedVisitId
    
    );