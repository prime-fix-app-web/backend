using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record CreateVisitRequest(
    
    [property:JsonPropertyName("failure")][Required][MaxLength(100)] string Failure,
    [property:JsonPropertyName("vehicleId")][Required] VehicleId VehicleId,
    [property:JsonPropertyName("timeVisit")][Required] string TimeVisit,
    [property:JsonPropertyName("autoRepairId")][Required] AutoRepairId AutoRepairId,
    [property:JsonPropertyName("serviceId")][Required] ServiceId ServiceId
    );