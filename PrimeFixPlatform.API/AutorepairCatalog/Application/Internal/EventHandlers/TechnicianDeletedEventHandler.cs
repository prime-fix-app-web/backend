using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Events;
using PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.EventHandlers;

/// <summary>
///     Event handler for TechnicianDeletedEvent
/// </summary>
/// <param name="autoRepairQueryService">
///     The auto repair query service to retrieve and update auto repair information
/// </param>
/// <param name="logger">
///     The logger to log information and errors
/// </param>
public class TechnicianDeletedEventHandler(
    IAutoRepairQueryService autoRepairQueryService,
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
        var autoRepair = await autoRepairQueryService.Handle(new GetAutoRepairByIdQuery(@event.AutoRepairId));
        if (autoRepair != null)
        {
            // Decrement the technicians count
            autoRepair.DecrementTechniciansCount();
            
            logger.LogInformation("Technician deleted for AutoRepair ID: {AutoRepairId}. Updated technicians count: {TechniciansCount}",
                @event.AutoRepairId, autoRepair.TechniciansCount);
            
            logger.LogInformation("Current number of technicians: {Count}", autoRepair.TechniciansCount);
        }
        else
        {
            logger.LogInformation("AutoRepair with ID: {AutoRepairId} not found.", @event.AutoRepairId);
        }
    }
}