using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.CommandServices;

/// <summary>
///     Command service for managing notifications.
/// </summary>
/// <param name="notificationRepository">
///     The notification repository.
/// </param>
/// <param name="unitOfWork">
///     Unit of work for transaction management.
/// </param>
public class NotificationCommandService(INotificationRepository notificationRepository,
    IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
: INotificationCommandService
{
    /// <summary>
    ///     Handle the creation of a new notification.
    /// </summary>
    /// <param name="command">
    ///     The command containing notification details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the ID of the created notification.
    /// </returns>
    public async Task<int> Handle(CreateNotificationCommand command)
    {
        var vehicleId = command.VehicleId;
        // Verify that the vehicle exists
        if (!await vehicleRepository.ExistsByVehicleId(vehicleId))
            throw new NotFoundIdException("Vehicle with id " + vehicleId + " does not exist");
        
        // Retrieve the vehicle
        var vehicle = await vehicleRepository.FindByIdAsync(vehicleId);
        if (vehicle is null)
            throw new NotFoundArgumentException("Vehicle not found");
        
        // Create and persist the new notification
        var notification = new Notification(command);
        await notificationRepository.AddAsync(notification);
        notification.Vehicle = vehicle;
        await unitOfWork.CompleteAsync();
        return notification.Id;
    }

    /// <summary>
    ///     Handle the update of an existing notification.
    /// </summary>
    /// <param name="command">
    ///     The command containing updated notification details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated notification.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the notification to be updated does not exist.
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the notification to be updated was not found.
    /// </exception>
    public async Task<Notification?> Handle(UpdateNotificationCommand command)
    {
        var notificationId = command.NotificationId;
        var vehicleId = command.VehicleId;
        
        // Verify that the vehicle exists
        if (!await vehicleRepository.ExistsByVehicleId(vehicleId))
            throw new NotFoundIdException("Vehicle with id " + vehicleId + " does not exist");
        
        // Verify that the notification exists
        if (!await notificationRepository.ExistsByNotificationId(notificationId))
            throw new NotFoundIdException("Notification with id " + notificationId  + " does not exist");
        
        // Retrieve the vehicle
        var vehicle = await vehicleRepository.FindByIdAsync(vehicleId);
        if (vehicle is null)
            throw new NotFoundArgumentException("Vehicle not found");
        
        // Retrieve the notification to update
        var notificationToUpdate = await notificationRepository.FindByIdAsync(notificationId);
        if (notificationToUpdate is null)
            throw new NotFoundArgumentException("Notification not found");
        
        // Update notification details
        notificationToUpdate.UpdateNotification(command);
        notificationRepository.Update(notificationToUpdate);

        notificationToUpdate.Vehicle = vehicle;
        
        // Persist changes
        await unitOfWork.CompleteAsync();
        return notificationToUpdate;
    }

    /// <summary>
    ///     Handle the deletion of a notification.
    /// </summary>
    /// <param name="command">
    ///     The command containing the ID of the notification to delete.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result indicates whether the deletion was successful.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the notification to be deleted does not exist.
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the notification to be deleted was not found.
    /// </exception>
    public async Task<bool> Handle(DeleteNotificationCommand command)
    {
        // Verify that the notification exists
        if (!await notificationRepository.ExistsByNotificationId(command.NotificationId))
            throw new NotFoundIdException("Notification with id " + command.NotificationId  + " does not exist");
        // Retrieve the notification to delete
        var notification = await notificationRepository.FindByIdAsync(command.NotificationId);
        if (notification is null)
            throw new NotFoundArgumentException("Notification not found");
        
        // Delete the notification
        notificationRepository.Remove(notification);
        await unitOfWork.CompleteAsync();
        return true;
    }
}