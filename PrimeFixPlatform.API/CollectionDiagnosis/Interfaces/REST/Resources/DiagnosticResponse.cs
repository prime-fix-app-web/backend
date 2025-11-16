using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record DiagnosticResponse(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("price")] float Price,
    [property: JsonPropertyName("vehicle_id")] string VehicleId,
    [property: JsonPropertyName("diagnosis")] string Diagnosis,
    [property: JsonPropertyName("expected_visit_id")] string ExpectedVisitId
    );