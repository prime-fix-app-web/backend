using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;

/// <summary>
///     Represents a service for handling notification-related commands.
/// </summary>
public interface INotificationCommandService
{
    /// <summary>
    ///     Handles the creation of a new notification.
    /// </summary>
    /// <param name="command">
    ///     The command containing notification creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created Notification entity, or null if creation failed.
    /// </returns>
    Task<string> Handle(CreateNotificationCommand command);
    
    /// <summary>
    ///     Handles the update of an existing notification.
    /// </summary>
    /// <param name="command">
    ///     The command containing notification update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated Notification entity, or null if the notification was not found.
    /// </returns>
    Task<Notification?> Handle(UpdateNotificationCommand command);
    
    /// <summary>
    ///     Handles the deletion of a notification.
    /// </summary>
    /// <param name="command">
    ///     The command containing notification deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteNotificationCommand command);
}