using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;

/// <summary>
/// Represents the repository interface for managing visit entities
/// </summary>
public interface IVisitRepository :IBaseRepository<Visit>
{
    /// <summary>
    ///     Find visits by auto repair ID.
    /// </summary>
    Task<Visit?> FindByAutoRepairId(int autoRepairId);
    
    /// <summary>
    /// Retrieves a <see cref="Visit"/> entity by the associated service identifier.
    /// </summary>
    /// <param name="serviceId">
    /// Identifier of the service.
    /// </param>
    Task<Visit?> FindByServiceId(int serviceId);
    
    /// <summary>
    /// Retrieves a <see cref="Visit"/> entity by the associated vehicle identifier.
    /// </summary>
    /// <param name="vehicleId">
    /// Identifier of the vehicle.
    /// </param>
    Task<Visit?> FindByVehicleId(int vehicleId);
    
    /// <summary>
    /// Retrieves a <see cref="Visit"/> entity by its unique identifier.
    /// </summary>
    /// <param name="clientId">
    /// Identifier of the visit (note: parameter name may represent visit id).
    /// </param>
    Task<Visit?> FindById(int clientId);
}