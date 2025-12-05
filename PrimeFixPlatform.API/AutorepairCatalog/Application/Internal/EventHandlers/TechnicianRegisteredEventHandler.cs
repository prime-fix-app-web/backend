using Cortex.Mediator.Notifications;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Events;
using PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.EventHandlers;

public class TechnicianRegisteredEventHandler(
    IAutoRepairQueryService autoRepairQueryService,
    ILogger<TechnicianRegisteredEventHandler> logger)
    : IEventHandler<TechnicianRegisteredEvent>
{
    public Task Handle(TechnicianRegisteredEvent registeredEvent, CancellationToken cancellationToken)
    {
        return On(registeredEvent);
    }

    public async Task On(TechnicianRegisteredEvent @event)
    {
        var autoRepair = await autoRepairQueryService.Handle(new GetAutoRepairByIdQuery(@event.AutoRepairId));
        if (autoRepair != null)
        {
            // Increment the technicians count
            autoRepair.IncrementTechniciansCount();
            
            logger.LogInformation("Technician registered for AutoRepair ID: {AutoRepairId}. Updated technicians count: {TechniciansCount}",
                @event.AutoRepairId, autoRepair.TechniciansCount);
            
            logger.LogInformation("Current number of technicians: {Count}", autoRepair.TechniciansCount);
        }
        else
        {
            logger.LogInformation("AutoRepair with ID: {AutoRepairId} not found.", @event.AutoRepairId);
        }
    }
}