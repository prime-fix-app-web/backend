using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

/// <summary>
///     Response for a diagnostic
/// </summary>
/// <param name="Id">
///     The identifier of the diagnostic
/// </param>
/// <param name="Price">
///     The price of the diagnostic
/// </param>
/// <param name="VehicleId">
///     The identifier of the vehicle
/// </param>
/// <param name="Diagnosis">
///     The diagnosis description
/// </param>
public record DiagnosticResponse(
    int Id,
    float Price,
    [property: JsonPropertyName("vehicle_id")] int VehicleId,
    string Diagnosis);