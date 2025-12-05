using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record DiagnosticResponse(
    int Id,
    float Price,
    [property: JsonPropertyName("vehicle_id")] int VehicleId,
    string Diagnosis,
    [property: JsonPropertyName("expected_visit_id")] int ExpectedVisitId);