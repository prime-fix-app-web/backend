using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record DiagnosticResponse(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("price")] float Price,
    [property: JsonPropertyName("vehicle_id")] int VehicleId,
    [property: JsonPropertyName("diagnosis")] string Diagnosis,
    [property: JsonPropertyName("expected_visit_id")] int ExpectedVisitId
    );