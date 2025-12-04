using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.AutorepairRegister.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Technician entities.
/// </summary>
/// <param name="context">
///     The database context used for data access.
/// </param>
public class TechnicianRepository(AppDbContext context)
: BaseRepository<Technician>(context), ITechnicianRepository
{
    /// <summary>
    ///     Checks if a Technician entity exists by its unique identifier.
    /// </summary>
    /// <param name="technicianId">
    ///     The unique identifier of the Technician entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a Technician entity with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByTechnicianId(int technicianId)
    {
        return await Context.Set<Technician>().AnyAsync(technician => technician.Id == technicianId);
    }
}