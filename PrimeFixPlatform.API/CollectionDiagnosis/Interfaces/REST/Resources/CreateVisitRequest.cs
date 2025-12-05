using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record CreateVisitRequest(
    
    [Required][MaxLength(100)] string Failure,
    [property:JsonPropertyName("vehicle_id")][Required] VehicleId VehicleId,
    [property:JsonPropertyName("time_visit")][Required] string TimeVisit,
    [property:JsonPropertyName("auto_repair_id")][Required] AutoRepairId AutoRepairId,
    [property:JsonPropertyName("service_id")][Required] ServiceId ServiceId);