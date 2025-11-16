using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record VisitResponse(
    [property:JsonPropertyName("id")] string Id,
    [property:JsonPropertyName("failure")] string Failure,
    [property:JsonPropertyName("vehicleId")] string VehicleId,
    [property:JsonPropertyName("timeVisit")] string TimeVisit,
    [property:JsonPropertyName("autoRepairId")] string AutoRepairId,
    [property:JsonPropertyName("serviceId")] string ServiceId
    );