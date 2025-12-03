using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing expected visits entities
/// </summary>
public interface IExpectedVisitRepository : IBaseRepository<ExpectedVisit>
{
    Task<ExpectedVisit?> FindByVisitId(int visitId);
}