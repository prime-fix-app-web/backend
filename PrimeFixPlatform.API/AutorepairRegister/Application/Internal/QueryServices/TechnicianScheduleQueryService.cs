using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairRegister.Application.Internal.QueryServices;

/// <summary>
///     Query service for managing TechnicianSchedule entities.
/// </summary>
/// <param name="technicianScheduleRepository">
///     The technician schedule repository.
/// </param>
public class TechnicianScheduleQueryService(ITechnicianScheduleRepository technicianScheduleRepository)
: ITechnicianScheduleQueryService
{
    /// <summary>
    ///     Handles the retrieval of all technician schedules.
    /// </summary>
    /// <param name="query">
    ///     The query to get all technician schedules.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of all TechnicianSchedule entities.
    /// </returns>
    public async Task<IEnumerable<TechnicianSchedule>> Handle(GetAllTechnicianSchedulesQuery query)
    {
        return await technicianScheduleRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the retrieval of a technician schedule by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to get a technician schedule by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the TechnicianSchedule entity if found; otherwise, throws NotFoundIdException.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the TechnicianSchedule with the specified ID was not found.
    /// </exception>
    public async Task<TechnicianSchedule?> Handle(GetTechnicianScheduleByIdQuery query)
    {
        return await technicianScheduleRepository.FindByIdAsync(query.TechnicianScheduleId)
            ?? throw new NotFoundIdException("TechnicianSchedule with the id " + query.TechnicianScheduleId + " was not found.");
    }
}