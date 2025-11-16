using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Infrastructure.Persistence.EFC.Repositories;
/// <summary>
///     Repository for managing Visit entities
/// </summary>
/// <param name="context">
///     The database context used for data access
/// </param>
public class VisitRepository(AppDbContext context) : BaseRepository<Visit>(context), IVisitRepository
{
    /// <summary>
    ///     Finds the first Visit associated with the given AutoRepair ID.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The AutoRepair identifier used to filter Visit records.
    /// </param>
    /// <returns>
    ///     The matching Visit if found; otherwise, null.
    /// </returns>
    public async Task<Visit?> FindByAutoRepairId(string autoRepairId)
    {
        return await Context.Set<Visit>().FirstOrDefaultAsync(visit => visit.AutoRepairId == autoRepairId);        
    }
}