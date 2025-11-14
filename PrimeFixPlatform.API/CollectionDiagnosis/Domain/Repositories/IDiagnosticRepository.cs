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
    ///     Find diagnosis by Vehicle Id
    /// </summary>
    Task<IEnumerable<Diagnostic>> FindByVehicleId(string vehicleId);
}