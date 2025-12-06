using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record VisitResponse(
    int Id,
    string Failure,
    [property:JsonPropertyName("vehicle_id")] int VehicleId,
    [property:JsonPropertyName("time_visit")] DateTime TimeVisit,
    [property:JsonPropertyName("auto_repair_id")] int AutoRepairId,
    [property:JsonPropertyName("service_id")] int ServiceId);