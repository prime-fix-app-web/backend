using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Queries;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Services;

/// <summary>
///     Represents a repository interface for handling technician schedule queries.
/// </summary>
public interface ITechnicianScheduleQueryService
{
    /// <summary>
    ///     Handles the GetAllTechnicianSchedulesQuery to retrieve all technician schedules.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving technician schedules.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable of technician schedules.
    /// </returns>
    Task<IEnumerable<TechnicianSchedule>> Handle(GetAllTechnicianSchedulesQuery query);
    
    /// <summary>
    ///     Handles the GetTechnicianScheduleByIdQuery to retrieve a technician schedule by its ID.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the technician schedule to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the technician schedule if found; otherwise, null.
    /// </returns>
    Task<TechnicianSchedule?> Handle(GetTechnicianScheduleByIdQuery query);
}