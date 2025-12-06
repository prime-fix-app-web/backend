using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Events;
using PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.EventHandlers;

/// <summary>
///     Event handler for TechnicianDeletedEvent
/// </summary>
/// <param name="autoRepairRepository">
///     The auto repair query service to retrieve and update auto repair information
/// </param>
/// <param name="unitOfWork">
///     Unit of work for managing transactions
/// </param>
/// <param name="logger">
///     The logger to log information and errors
/// </param>
public class TechnicianDeletedEventHandler(
    IAutoRepairRepository autoRepairRepository,
    IUnitOfWork unitOfWork,
    ILogger<TechnicianDeletedEventHandler> logger)
    : IEventHandler<TechnicianDeletedEvent>
{
    /// <summary>
    ///     Handle the TechnicianDeletedEvent
    /// </summary>
    /// <param name="notification">
    ///     The TechnicianDeletedEvent notification
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation
    /// </returns>
    public Task Handle(TechnicianDeletedEvent notification, CancellationToken cancellationToken)
    {
        return On(notification);
    }
    
    /// <summary>
    ///     On technician deleted event
    /// </summary>
    /// <param name="event">
    ///     The TechnicianDeletedEvent
    /// </param>
    public async Task On(TechnicianDeletedEvent @event)
    {
        // Retrieve the auto repair by ID
        var autoRepair = await autoRepairRepository.FindByIdAsync(@event.AutoRepairId);

        // If auto repair not found, log and exit
        if (autoRepair == null)
        {
            logger.LogInformation("AutoRepair with ID: {AutoRepairId} not found.", @event.AutoRepairId);
            return;
        }
       // Decrement the technician count
        autoRepair.DecrementTechniciansCount();
        
        // Save changes
        await unitOfWork.CompleteAsync();

        // Log the update
        logger.LogInformation(
            "Technician registered for AutoRepair ID: {AutoRepairId}. Updated technicians count: {TechniciansCount}",
            @event.AutoRepairId, autoRepair.TechniciansCount);
    }
}