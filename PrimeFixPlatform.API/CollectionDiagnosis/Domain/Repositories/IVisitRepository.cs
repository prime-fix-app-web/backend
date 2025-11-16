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
    Task<Visit?> FindByAutoRepairId(string autoRepairId);
}