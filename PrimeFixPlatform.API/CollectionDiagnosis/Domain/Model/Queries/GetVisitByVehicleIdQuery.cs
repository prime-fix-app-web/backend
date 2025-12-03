namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

/// <summary>
///     Query to retrieve a visit by Vehicle ID
/// </summary>
/// <param name="VehicleId">
///     The vehicle ID
/// </param>
public record GetVisitByVehicleIdQuery(int VehicleId);