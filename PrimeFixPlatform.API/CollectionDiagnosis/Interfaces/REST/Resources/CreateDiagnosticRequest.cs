using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

/// <summary>
///     Request to create a new diagnostic
/// </summary>
/// <param name="Price">
///     The price of the diagnostic
/// </param>
/// <param name="VehicleId">
///     The identifier of the vehicle
/// </param>
/// <param name="Diagnosis">
///     The diagnosis description
/// </param>
public record CreateDiagnosticRequest(
    [Required]
    float Price,
    
    [property:JsonPropertyName("vehicle_id")]
    [Required]
    int VehicleId,
    
    [Required]
    [MaxLength(100)]
    string Diagnosis);