using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;

/// <summary>
///    Represents the repository interface for managing Notification entities.
/// </summary>
public interface INotificationRepository : IBaseRepository<Notification>
{
    /// <summary>
    ///     Checks if a notification exists by its unique identifier.
    /// </summary>
    /// <param name="notificationId">
    ///     The unique identifier of the notification.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a notification with the specified ID exists.
    /// </returns>
    Task<bool> ExistsByIdNotification(int notificationId);
}