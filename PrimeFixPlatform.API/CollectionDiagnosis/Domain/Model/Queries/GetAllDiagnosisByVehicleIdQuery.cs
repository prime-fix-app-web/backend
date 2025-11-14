namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

/// <summary>
///     Query to retrieve all diagnosis by Vehicle ID
/// </summary>
/// <param name="VehicleId">
///     The ID of the vehicle 
/// </param>
public record GetAllDiagnosisByVehicleIdQuery(string  VehicleId);