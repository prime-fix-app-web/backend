using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Notification-related requests, commands, and responses.
/// </summary>
public class NotificationAssembler
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
            request.IdNotification, request.Message, request.Read, 
            request.IdVehicle, request.Sent, request.IdDiagnostic
            );
    }
    
    /// <summary>
    ///     Converts an UpdateNotificationRequest to an UpdateNotificationCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateNotificationRequest containing updated notification details.
    /// </param>
    /// <param name="idNotification">
    ///     The identifier of the notification to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateNotificationCommand.
    /// </returns>
    public static UpdateNotificationCommand ToCommandFromRequest(UpdateNotificationRequest request, string idNotification)
    {
        return new UpdateNotificationCommand(
            idNotification, request.Message, request.Read, 
            request.IdVehicle, request.Sent, request.IdDiagnostic
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
            entity.IdNotification, entity.Message, entity.Read, 
            entity.IdVehicle, entity.Sent, entity.IdDiagnostic
            );
    }
}