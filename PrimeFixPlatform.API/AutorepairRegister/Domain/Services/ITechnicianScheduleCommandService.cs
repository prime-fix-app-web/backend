using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Services;

/// <summary>
///     Represents a service for handling technician schedule-related commands.
/// </summary>
public interface ITechnicianScheduleCommandService
{
    /// <summary>
    ///     Handles the creation of a new technician schedule.
    /// </summary>
    /// <param name="command">
    ///     The command containing technician schedule creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the ID of the created TechnicianSchedule entity, or null if creation
    /// </returns>
    Task<string> Handle(CreateTechnicianScheduleCommand command);
    
    /// <summary>
    ///     Handles the update of an existing technician schedule.
    /// </summary>
    /// <param name="command">
    ///     The command containing technician schedule update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated TechnicianSchedule entity, or null if the technician schedule was not found.
    /// </returns>
    Task<TechnicianSchedule?> Handle(UpdateTechnicianScheduleCommand command);
    
    /// <summary>
    ///     Handles the deletion of a technician schedule.
    /// </summary>
    /// <param name="command">
    ///     The command containing technician schedule deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteTechnicianScheduleCommand command);
}