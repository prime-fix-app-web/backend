namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///     Command to update an existing diagnosis 
/// </summary>
/// <param name="DiagnosisId">
///     The ID of the diagnosis to be updated
/// </param>
/// <param name="Price">
///     The price assigned for the diagnosis
/// </param>
/// <param name="VehicleId">
///     The ID of the vehicle assigned for the diagnosis
/// </param>
/// <param name="Diagnosis">
///     The description of the diagnosis
/// </param>
/// <param name="ExpectedId">
///     The ID of the expected visit.
/// </param>
public record UpdateDiagnosisCommand(string DiagnosisId, float Price,string VehicleId, string Diagnosis, string ExpectedId );