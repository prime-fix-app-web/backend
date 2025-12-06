using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

/// <summary>
///     Request to create a new visit
/// </summary>
/// <param name="Failure">
///     The description of the vehicle failure
/// </param>
/// <param name="VehicleId">
///     The identifier of the vehicle
/// </param>
/// <param name="TimeVisit">
///     The scheduled time for the visit
/// </param>
/// <param name="AutoRepairId">
///     The identifier of the auto repair shop
/// </param>
/// <param name="ServiceId">
///     The identifier of the service to be performed
/// </param>
public record CreateVisitRequest(
    [Required][MaxLength(100)] string Failure,
    [property:JsonPropertyName("vehicle_id")][Required] int VehicleId,
    [property:JsonPropertyName("time_visit")] [Required] DateTime TimeVisit,
    [property:JsonPropertyName("auto_repair_id")][Required] int AutoRepairId,
    [property:JsonPropertyName("service_id")][Required] int ServiceId);