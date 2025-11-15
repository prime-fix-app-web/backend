using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;

/// <summary>
///     Represents a service for handling auto repair-related commands.
/// </summary>
public interface IAutoRepairCommandService
{
    /// <summary>
    ///     Handles the creation of a new auto repair entry.
    /// </summary>
    /// <param name="command">
    ///     The command containing auto repair creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created AutoRepair entity, or null if creation failed.
    /// </returns>
    Task<string> Handle(CreateAutoRepairCommand command);
    
    /// <summary>
    ///     Handles the update of an existing auto repair entry.
    /// </summary>
    /// <param name="command">
    ///     The command containing auto repair update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated AutoRepair entity, or null if the auto repair was not found.
    /// </returns>
    Task<AutoRepair?> Handle(UpdateAutoRepairCommand command);
    
    /// <summary>
    ///     Handles the deletion of an auto repair entry.
    /// </summary>
    /// <param name="command">
    ///     The command containing auto repair deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteAutoRepairCommand command);
}