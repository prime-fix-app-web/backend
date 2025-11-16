using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Services;

/// <summary>
///     Represents a service for handling technician-related commands.
/// </summary>
public interface ITechnicianCommandService
{
    /// <summary>
    ///     Handles the creation of a new technician.
    /// </summary>
    /// <param name="command">
    ///     The command containing technician creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the ID of the created Technician entity, or null if creation
    /// </returns>
    Task<string> Handle(CreateTechnicianCommand command);
    
    /// <summary>
    ///     Handles the update of an existing technician.
    /// </summary>
    /// <param name="command">
    ///     The command containing technician update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated Technician entity, or null if the technician was not found.
    /// </returns>
    Task<Technician?> Handle(UpdateTechnicianCommand command);
    
    /// <summary>
    ///     Handles the deletion of a technician.
    /// </summary>
    /// <param name="command">
    ///     The command containing technician deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteTechnicianCommand command);
}