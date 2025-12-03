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
    public async Task<ExpectedVisit?> FindByVisitId(int visitId)
    {
        return await Context.Set<ExpectedVisit>().FindAsync(visitId);
    }
}