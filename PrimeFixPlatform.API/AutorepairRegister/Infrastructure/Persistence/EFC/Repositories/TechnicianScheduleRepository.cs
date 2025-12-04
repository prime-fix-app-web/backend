using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.AutorepairRegister.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing TechnicianSchedule entities.
/// </summary>
/// <param name="context">
///     The database context used for data access.
/// </param>
public class TechnicianScheduleRepository(AppDbContext context)
: BaseRepository<TechnicianSchedule>(context), ITechnicianScheduleRepository
{
    /// <summary>
    ///     Checks if a TechnicianSchedule entity exists by its schedule identifier.
    /// </summary>
    /// <param name="idSchedule">
    ///     The unique identifier of the schedule.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a TechnicianSchedule entity with the specified schedule identifier exists.
    /// </returns>
    public async Task<bool> ExistsByIdSchedule(int idSchedule)
    {
        return await Context.Set<TechnicianSchedule>().AnyAsync(technicianSchedule => technicianSchedule.ScheduleId == idSchedule);
    }
}