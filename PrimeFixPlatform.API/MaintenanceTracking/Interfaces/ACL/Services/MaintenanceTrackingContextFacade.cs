using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.ACL.Services;

/// <summary>
///     Context facade for maintenance tracking operations.
/// </summary>
/// <param name="vehicleCommandService">
///     The vehicle command service.
/// </param>
/// <param name="vehicleQueryService">
///     The vehicle query service.
/// </param>
/// <param name="notificationCommandService">
///     The notification command service.
/// </param>
/// <param name="notificationQueryService">
///     The notification query service.
/// </param>
public class MaintenanceTrackingContextFacade 
(IVehicleCommandService vehicleCommandService, IVehicleQueryService vehicleQueryService,
    INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService)
    : IMaintenanceTrackingContextFacade
{
    /// <summary>
    ///     Checks if a vehicle exists by its unique identifier.
    /// </summary>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the vehicle exists.
    /// </returns>
    public async Task<bool> ExistsVehicleByIdAsync(int vehicleId)
    {
        return await vehicleQueryService.Handle(new ExistsVehicleByIdQuery(vehicleId));
    }

    /// <summary>
    ///     Checks if a notification exists by its unique identifier.
    /// </summary>
    /// <param name="notificationId">
    ///     The unique identifier of the notification.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the notification exists.
    /// </returns>
    public async Task<bool> ExistsNotificationByIdAsync(int notificationId)
    {
        return await notificationQueryService.Handle(new ExistsNotificationByIdQuery(notificationId));
    }

    /// <summary>
    ///     Updates an existing vehicle.
    /// </summary>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle to be updated.
    /// </param>
    /// <param name="color">
    ///     The color of the vehicle.
    /// </param>
    /// <param name="model">
    ///     The model of the vehicle.
    /// </param>
    /// <param name="userId">
    ///     The unique identifier of the user associated with the vehicle.
    /// </param>
    /// <param name="vehicleBrand">
    ///     The brand of the vehicle.
    /// </param>
    /// <param name="vehiclePlate">
    ///     The license plate of the vehicle.
    /// </param>
    /// <param name="vehicleType">
    ///     The type of the vehicle.
    /// </param>
    /// <param name="maintenanceStatus">
    ///     The maintenance status of the vehicle.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the unique identifier of the updated vehicle.
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the vehicle with the specified ID was not found.
    /// </exception>
    public async Task<int> UpdateVehicleAsync(int vehicleId, string color, string model, int userId, string vehicleBrand, string vehiclePlate,
        string vehicleType, int maintenanceStatus)
    {
        var updateVehicleCommand = VehicleAssembler.ToCommandFromValues(vehicleId, color, model, userId,
            vehicleBrand, vehiclePlate, vehicleType, maintenanceStatus);
        var updatedVehicle = await vehicleCommandService.Handle(updateVehicleCommand);
        
        if (updatedVehicle == null)
        {
            throw new NotFoundArgumentException($"Vehicle with ID {vehicleId} not found.");
        }
        return updatedVehicle.Id;
    }

    /// <summary>
    ///     Creates a new notification.
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
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the unique identifier of the created notification.
    /// </returns>
    public async Task<int> CreateNotificationAsync(string message, int vehicleId, DateOnly sent)
    {
        var createNotificationCommand = NotificationAssembler.ToCommandFromValues(message, vehicleId, sent);
        return await notificationCommandService.Handle(createNotificationCommand);
    }

    /// <summary>
    ///     Updates an existing notification.
    /// </summary>
    /// <param name="notificationId">
    ///     The unique identifier of the notification to be updated.
    /// </param>
    /// <param name="read">
    ///     The read status of the notification.
    /// </param>
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
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the unique identifier of the updated notification.
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the notification with the specified ID was not found.
    /// </exception>
    public async Task<int> UpdateNotificationAsync(int notificationId, bool read, string message, int vehicleId, DateOnly sent)
    {
        var updateNotificationCommand = NotificationAssembler.ToCommandFromValues(notificationId, read, message, vehicleId, sent);
        var updatedNotification = await notificationCommandService.Handle(updateNotificationCommand);
        
        if (updatedNotification == null)
        {
            throw new NotFoundArgumentException($"Notification with ID {notificationId} not found.");
        }
        return updatedNotification.Id;
    }
}