using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing Diagnostic entities
/// </summary>
public interface IDiagnosticRepository : IBaseRepository<Diagnostic>
{

    /// <summary>
    ///     Find diagnosis by Vehicle ID
    /// </summary>
    Task<Diagnostic?> FindByVehicleId(VehicleId vehicleId);
    
    /// <summary>
    ///     Find diagnostic by expected visit ID
    /// </summary>
    Task<Diagnostic?> FindByExpectedId(int expectedId);
    
}