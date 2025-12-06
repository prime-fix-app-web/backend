using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Notification-related requests, commands, and responses.
/// </summary>
public static class NotificationAssembler
{
    /// <summary>
    ///     Converts a CreateNotificationRequest to a CreateNotificationCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateNotificationRequest containing notification details.
    /// </param>
    /// <returns>
    ///    The corresponding CreateNotificationCommand.
    /// </returns>
    public static CreateNotificationCommand ToCommandFromRequest(CreateNotificationRequest request)
    {
        return new CreateNotificationCommand(
            request.Message,
            request.VehicleId, request.Sent);
    }

    /// <summary>
    ///     Converts values to a CreateNotificationCommand.
    /// </summary>
    /// <param name="message">
    ///     The message content of the notification.
    /// </param>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle associated with the notification.
    /// </param>
    /// <param name="sent">
    ///     The date the notification was sent.
    /// </param>
    /// <returns>
    ///     The corresponding CreateNotificationCommand.
    /// </returns>
    public static CreateNotificationCommand ToCommandFromValues(string message, int vehicleId, DateOnly sent)
    {
        return new CreateNotificationCommand(
            message,
            vehicleId, sent);
    }
    
    /// <summary>
    ///     Converts an UpdateNotificationRequest to an UpdateNotificationCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateNotificationRequest containing updated notification details.
    /// </param>
    /// <param name="notificationId">
    ///     The identifier of the notification to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateNotificationCommand.
    /// </returns>
    public static UpdateNotificationCommand ToCommandFromRequest(UpdateNotificationRequest request, int  notificationId)
    {
        return new UpdateNotificationCommand(
            notificationId, request.Message, request.Read, 
            request.VehicleId, request.Sent
            );
    }

    public static UpdateNotificationCommand ToCommandFromValues(int notificationId, bool read, string message, int vehicleId, DateOnly sent)
    {
        return new UpdateNotificationCommand(
            notificationId, message, read, 
            vehicleId, sent
            );
    }
    
    /// <summary>
    ///     Converts a Notification entity to a NotificationResponse.
    /// </summary>
    /// <param name="entity">
    ///     The Notification entity containing notification details.
    /// </param>
    /// <returns>
    ///     The corresponding NotificationResponse.
    /// </returns>
    public static NotificationResponse ToResponseFromEntity(Notification entity)
    {
        return new NotificationResponse(
            entity.Id, entity.Message, entity.Read, 
            entity.VehicleId, entity.Sent);
    }
}