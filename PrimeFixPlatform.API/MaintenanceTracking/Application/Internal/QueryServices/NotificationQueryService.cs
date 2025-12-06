using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.QueryServices;

/// <summary>
///     Query service for managing Notification entities.
/// </summary>
/// <param name="notificationRepository">
///     The notification repository.
/// </param>
public class NotificationQueryService(INotificationRepository notificationRepository)
: INotificationQueryService
{
    /// <summary>
    ///     Handles the retrieval of all notifications.
    /// </summary>
    /// <param name="query">
    ///     The query to get all notifications.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of all Notification entities.
    /// </returns>
    public async Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query)
    {
        return await notificationRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the retrieval of a notification by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to get a notification by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the Notification entity if found; otherwise, throws NotFoundIdException.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a notification with the specified ID was not found.
    /// </exception>
    public async Task<Notification?> Handle(GetNotificationByIdQuery query)
    {
        return await notificationRepository.FindByIdAsync(query.NotificationId)
            ?? throw new NotFoundIdException("Notification with the id " + query.NotificationId + " was not found.");
    }

    /// <summary>
    ///     Handles the check for the existence of a notification by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to check if a notification exists by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean value indicating whether the notification exists.
    /// </returns>
    public async Task<bool> Handle(ExistsNotificationByIdQuery query)
    {
        return await notificationRepository.ExistsByNotificationId(query.NotificationId);
    }
}