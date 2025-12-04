using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing expected visits entities
/// </summary>
public interface IExpectedVisitRepository : IBaseRepository<ExpectedVisit>
{
    /// <summary>
    /// Retrieves an <see cref="ExpectedVisit"/> entity by its associated visit identifier.
    /// </summary>
    /// <param name="visitId">
    /// Identifier of the related visit.
    /// </param>
    Task<ExpectedVisit?> FindByVisitId(int visitId);
    
    /// <summary>
    /// Retrieves an <see cref="ExpectedVisit"/> entity by its own identifier.
    /// </summary>
    /// <param name="expectedVisitId">
    /// Identifier of the expected visit.
    /// </param>
    Task<ExpectedVisit?> FindById(int expectedVisitId);
}