using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

/// <summary>
///      Command to create a new Diagnosis
/// </summary>
/// <param name="Price">
///     The estimated price of the Diagnosis
/// </param>
/// <param name="VehicleId">
///     The vehicle ID of the Diagnosis
/// </param>
/// <param name="Diagnosis">
///     The description of the Diagnosis
/// </param>
public record CreateDiagnosisCommand(float Price, int VehicleId, string Diagnosis );