using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

/// <summary>
///     Request to create an expected visit
/// </summary>
/// <param name="VisitId">
///     The identifier of the visit associated with the expected visit
/// </param>
/// <param name="VehicleId">
///     The identifier of the vehicle associated with the expected visit
/// </param>
public record CreateExpectedVisitRequest(
    [property:JsonPropertyName("visit_id")]
    int VisitId,
    [property:JsonPropertyName("vehicle_id")]
    int VehicleId);