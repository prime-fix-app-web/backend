using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Infrastructure.Persistence.EFC.Repositories;
/// <summary>
///     Repository for managing ExpectedVisit entities
/// </summary>
/// <param name="context">
///     The database context used for data access
/// </param>
public class ExpectedVisitRepository(AppDbContext context): BaseRepository<ExpectedVisit>(context), IExpectedVisitRepository
{
    /// <summary>
    ///     Find an ExpectedVisit by its associated Visit ID
    /// </summary>
    /// <param name="visitId">
    ///     The ID of the associated Visit
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation,
    ///     The task result contains the ExpectedVisit if found; otherwise, null
    /// </returns>
    public async Task<ExpectedVisit?> FindByVisitId(int visitId)
    {
        return await Context.Set<ExpectedVisit>().FindAsync(visitId);
    }

    /// <summary>
    ///     Find an ExpectedVisit by its ID
    /// </summary>
    /// <param name="expectedVisitId">
    ///     The ID of the ExpectedVisit
    /// </param >
    /// <returns>
    ///     A task that represents the asynchronous operation,
    ///     The task result contains the ExpectedVisit if found; otherwise, null
    /// </returns>
    public async Task<ExpectedVisit?> FindById(int expectedVisitId)
    {
        return await Context.Set<ExpectedVisit>().FindAsync(expectedVisitId);
    }
    
    /// <summary>
    ///     Checks if an Expected Visit exists for the given Visit ID.
    /// </summary>
    /// <param name="visitId">
    ///     The visit identifier.
    /// </param>
    /// <returns>
    ///     The task result contains true if an Expected Visit exists for the given Visit ID; otherwise, false.
    /// </returns>
    public async Task<bool> ExistByVisitId(int visitId)
    {
        var expectedVisit = await Context.Set<ExpectedVisit>()
            .FindAsync(visitId);
        return expectedVisit != null;
    }
}