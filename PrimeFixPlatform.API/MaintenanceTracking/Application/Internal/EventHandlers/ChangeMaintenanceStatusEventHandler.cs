using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Events;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.EventHandlers;

/// <summary>
///     Event handler for ChangeMaintenanceStatusEvent
/// </summary>
/// <param name="notificationCommandService">
///     The notification command service to handle notification commands
/// </param>
/// <param name="logger">
///     The logger to log information and errors
/// </param>
public class ChangeMaintenanceStatusEventHandler
(INotificationCommandService notificationCommandService,
    ILogger<ChangeMaintenanceStatusEventHandler> logger) : IEventHandler<ChangeMaintenanceStatusEvent>
{
    /// <summary>
    ///     Handle the ChangeMaintenanceStatusEvent
    /// </summary>
    /// <param name="notification">
    ///     The ChangeMaintenanceStatusEvent notification
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token
    /// </param>
    /// <returns></returns>
    public Task Handle(ChangeMaintenanceStatusEvent notification, CancellationToken cancellationToken)
    {
        return On(notification);
    }

    /// <summary>
    ///     On change maintenance status event
    /// </summary>
    /// <param name="event">
    ///     The ChangeMaintenanceStatusEvent
    /// </param>
    public async Task On(ChangeMaintenanceStatusEvent @event)
    {
         var createNotificationCommand = new CreateNotificationCommand(MaintenanceStatusInfo.GetNotificationMessage(@event.MaintenanceStatus)!,
             @event.VehicleId, DateOnly.FromDateTime(DateTime.Today));
         
         // Send notification
         var notificationId = await notificationCommandService.Handle(createNotificationCommand);
         
         // Log the notification creation
         logger.LogInformation("Notification created with ID: {NotificationId} for Maintenance ID: {MaintenanceId} with Status: {Status}",
             notificationId, @event.MaintenanceStatus.ToString(), @event.MaintenanceStatus);
    }
}