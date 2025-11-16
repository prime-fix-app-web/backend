using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing TechnicianSchedule entities.
/// </summary>
public interface ITechnicianScheduleRepository : IBaseRepository<TechnicianSchedule>
{
    /// <summary>
    ///     Checks if a TechnicianSchedule entity exists by its unique schedule identifier.
    /// </summary>
    /// <param name="idSchedule">
    ///     The unique identifier of the TechnicianSchedule entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether the TechnicianSchedule entity exists.
    /// </returns>
    Task<bool> ExistsByIdSchedule(string idSchedule);
}