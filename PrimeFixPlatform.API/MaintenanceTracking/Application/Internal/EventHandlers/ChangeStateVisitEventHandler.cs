using Humanizer;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.EventHandlers;

/// <summary>
///     Event handler for ChangeStateVisitEvent
/// </summary>
/// <param name="notificationCommandService">
///     The notification command service to handle notification commands
/// </param>
/// <param name="vehicleCommandService">
///     The vehicle command service to handle vehicle commands
/// </param>
/// <param name="vehicleQueryService">
///     The vehicle query service to handle vehicle queries
/// </param>
/// <param name="logger">
///     Logger to log information and errors
/// </param>
public class ChangeStateVisitEventHandler(
    INotificationCommandService notificationCommandService,
    IVehicleCommandService vehicleCommandService,
    IVehicleQueryService vehicleQueryService,
    ILogger<ChangeStateVisitEventHandler> logger)
    : IEventHandler<ChangeStateVisitEvent>
{
    public Task Handle(ChangeStateVisitEvent notification, CancellationToken cancellationToken)
    {
        return On(notification);
    }
    
    public async Task On(ChangeStateVisitEvent @event)
    {
        // Retrieve the vehicle by ID
        var vehicle = await vehicleQueryService.Handle(new GetVehicleByIdQuery(@event.VehicleId));
        if (vehicle is null)
        {
            logger.LogError("Vehicle with ID: {VehicleId} not found for Visit State Change Event", @event.VehicleId);
            return;
        }

        // If the visit state is SCHEDULED_VISIT, update the vehicle's maintenance status
        if (@event.StateVisit == EStateVisit.SCHEDULED_VISIT)
        {
            var updateVehicleCommand = new UpdateVehicleCommand(vehicle.Id, vehicle.Color, vehicle.Model, vehicle.UserId,
                vehicle.VehicleInformation, EMaintenanceStatus.Waiting);
            
            await vehicleCommandService.Handle(updateVehicleCommand);
        }
        // If the visit state is CANCELLED_VISIT, update the vehicle's maintenance status
        else if (@event.StateVisit == EStateVisit.CANCELLED_VISIT)
        {
            var updateCommand = new UpdateVehicleCommand(
                vehicle.Id,
                vehicle.Color,
                vehicle.Model,
                vehicle.UserId,
                vehicle.VehicleInformation,
                EMaintenanceStatus.NotBeingServiced
            );
            await vehicleCommandService.Handle(updateCommand);
        }
        
        // Log the vehicle update
        logger.LogInformation("Vehicle with ID: {VehicleId} has been updated.", vehicle.Id);
        
        var createNotificationCommand = new CreateNotificationCommand(
            @event.StateVisit.GetNotificationMessage(),
            @event.VehicleId,
            DateOnly.FromDateTime(DateTime.UtcNow)
        );
        
        // Send notification
        logger.LogInformation("Handling ChangeStateVisitEvent for Vehicle ID: {VehicleId}", @event.VehicleId);

        // Send notification
        var notificationId = await notificationCommandService.Handle(createNotificationCommand);
        
        // Log the notification creation
        if (notificationId == 0)
        {
            logger.LogError("Failed to create notification for Vehicle ID: {VehicleId}", @event.VehicleId);
        }
        else
        {
            logger.LogInformation(
                "Notification created with ID: {NotificationId} for Vehicle ID: {VehicleId}",
                notificationId,
                @event.VehicleId
            );
        }
    }
}