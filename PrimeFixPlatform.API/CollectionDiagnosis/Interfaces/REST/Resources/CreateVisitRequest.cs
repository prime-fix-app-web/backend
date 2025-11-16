using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record CreateVisitRequest(
    
    [property:JsonPropertyName("failure")][Required][MaxLength(100)] string Failure,
    [property:JsonPropertyName("vehicleId")][Required][MinLength(1)] string VehicleId,
    [property:JsonPropertyName("timeVisit")][Required] string TimeVisit,
    [property:JsonPropertyName("autoRepairId")][Required][MinLength(1)] string AutoRepairId,
    [property:JsonPropertyName("serviceId")][Required][MinLength(1)] string ServiceId
    );