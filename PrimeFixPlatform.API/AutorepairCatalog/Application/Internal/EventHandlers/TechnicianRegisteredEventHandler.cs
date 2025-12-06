using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Events;
using PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.EventHandlers;

/// <summary>
///     Event handler for TechnicianRegisteredEvent
/// </summary>
/// <param name="autoRepairRepository">
///     The auto repair repository to retrieve and update auto repair information
/// </param>
/// <param name="unitOfWork">
///     Unit of work for managing transactions
/// </param>
/// <param name="logger">
///     Logger to log information and errors
/// </param>
public class TechnicianRegisteredEventHandler(
    IAutoRepairRepository autoRepairRepository,
    IUnitOfWork unitOfWork,
    ILogger<TechnicianRegisteredEventHandler> logger)
    : IEventHandler<TechnicianRegisteredEvent>
{
    /// <summary>
    ///     Handle the TechnicianRegisteredEvent
    /// </summary>
    /// <param name="registeredEvent">
    ///     The TechnicianRegisteredEvent notification
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation 
    /// </returns>
    public Task Handle(TechnicianRegisteredEvent registeredEvent, CancellationToken cancellationToken)
    {
        return On(registeredEvent);
    }

    /// <summary>
    ///     On technician registered event
    /// </summary>
    /// <param name="event">
    ///     The TechnicianRegisteredEvent
    /// </param>
    public async Task On(TechnicianRegisteredEvent @event)
    {
        // Retrieve the auto repair by ID
        var autoRepair = await autoRepairRepository.FindByIdAsync(@event.AutoRepairId);

        // If auto repair not found, log and exit
        if (autoRepair == null)
        {
            logger.LogInformation("AutoRepair with ID: {AutoRepairId} not found.", @event.AutoRepairId);
            return;
        }
        
        // Increment the technician count
        autoRepair.IncrementTechniciansCount();
        
        // Save changes
        await unitOfWork.CompleteAsync();

        // Log the update
        logger.LogInformation(
            "Technician registered for AutoRepair ID: {AutoRepairId}. Updated technicians count: {TechniciansCount}",
            @event.AutoRepairId, autoRepair.TechniciansCount);
    }
}