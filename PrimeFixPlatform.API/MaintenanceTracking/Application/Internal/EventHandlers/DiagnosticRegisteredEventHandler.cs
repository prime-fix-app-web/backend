using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.EventHandlers;

/// <summary>
///     Event handler for DiagnosticRegisteredEvent
/// </summary>
/// <param name="notificationCommandService">
///     The notification command service
/// </param>
/// <param name="logger">
///     Logger instance
/// </param>
public class DiagnosticRegisteredEventHandler
(INotificationCommandService notificationCommandService,
    ILogger<DiagnosticRegisteredEventHandler> logger) : IEventHandler<DiagnosticRegisteredEvent>

{
    public Task Handle(DiagnosticRegisteredEvent notification, CancellationToken cancellationToken)
    {
        return On(notification);
    }
    
    /// <summary>
    ///     On diagnostic registered event
    /// </summary>
    /// <param name="event">
    ///     The diagnostic registered event
    /// </param>
    public async Task On(DiagnosticRegisteredEvent @event)
    {
        // Create a command to create a notification based on the diagnostic registered event
        var createNotificationCommand = new CreateNotificationCommand(
            @event.Diagnosis,
            @event.VehicleId,
            DateOnly.FromDateTime(DateTime.UtcNow)
        );

        logger.LogInformation(
            "Handling DiagnosticRegisteredEvent for Vehicle ID: {VehicleId}",
            @event.VehicleId
        );

        // Handle the command to create the notification
        var notificationId = await notificationCommandService.Handle(createNotificationCommand);


        // Log the result of the notification creation
        if (notificationId == 0)
        {
            logger.LogError(
                "Failed to create notification for Vehicle ID: {VehicleId}",
                @event.VehicleId
            );
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