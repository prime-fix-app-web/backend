using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;

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
    Task<int> Handle(CreateAutoRepairCommand command);
    
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
    
    
    /// <summary>
    ///     Handles adding a service to the AutoRepair service catalog.
    /// </summary>
    /// <param name="command">
    ///     The command containing the service id and the auto repair id.
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation.
    ///     The task result indicates whether the service was successfully added.
    /// </returns>
    Task<ServiceOffer> Handle(AddServiceToAutoRepairServiceCatalogCommand command);
    
    /// <summary>
    ///     Handles deleting a service to the AutoRepair service catalog
    /// </summary>
    /// <param name="command">
    ///     The command conatining the service id and the autorepair id
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation.
    ///     The task result indicates whether the service was successfully deleted.
    /// </returns>
    Task<bool> Handle(DeleteServiceToAutoRepairServiceCommand command);
}