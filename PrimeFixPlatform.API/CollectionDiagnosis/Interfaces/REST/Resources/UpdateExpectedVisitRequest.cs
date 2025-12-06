using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

/// <summary>
///     Representation of a request to update an expected visit.
/// </summary>
/// <param name="StateVisit">
///     The state of the visit.
/// </param>
/// <param name="VisitId">
///     The identifier of the visit.
/// </param>
/// <param name="IsScheduled">
///     Indicates whether the visit is scheduled.
/// </param>
/// <param name="VehicleId">
///     The identifier of the vehicle associated with the visit.
/// </param>
public record UpdateExpectedVisitRequest(
    [property:JsonPropertyName("state_visit")]
    string StateVisit,
    
    [property:JsonPropertyName("visit_id")]
    int VisitId,
    
    [property:JsonPropertyName("is_scheduled")]
    bool IsScheduled,
    
    [property:JsonPropertyName("vehicle_id")]
    int VehicleId);