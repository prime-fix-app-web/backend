using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record VisitResponse(
    [property:JsonPropertyName("id")] int Id,
    [property:JsonPropertyName("failure")] string Failure,
    [property:JsonPropertyName("vehicleId")] int VehicleId,
    [property:JsonPropertyName("timeVisit")] string TimeVisit,
    [property:JsonPropertyName("autoRepairId")] int AutoRepairId,
    [property:JsonPropertyName("serviceId")] int ServiceId
    );