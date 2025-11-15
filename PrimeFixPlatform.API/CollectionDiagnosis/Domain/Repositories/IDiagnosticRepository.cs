using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing Diagnostic entities
/// </summary>
public interface IDiagnosticRepository : IBaseRepository<Diagnostic>
{
    
    Task<bool> ExistByDiagnosticId(string diagnosticId);
    
    /// <summary>
    ///     Find diagnosis by Vehicle ID
    /// </summary>
    Task<Diagnostic?> FindByVehicleId(string vehicleId);
    
    Task<bool> FindByDiagnosisId(string diagnosisId);
    
}