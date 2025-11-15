using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.MaintenanceTracking.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Notification entities.
/// </summary>
/// <param name="context">
///     The database context.
/// </param>
public class NotificationRepository(AppDbContext context)
: BaseRepository<Notification>(context), INotificationRepository
{
    /// <summary>
    ///     Checks if a notification exists by its unique identifier.
    /// </summary>
    /// <param name="idNotification">
    ///     The unique identifier of the notification.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a notification with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByIdNotification(string idNotification)
    {
        return await Context.Set<Notification>()
            .AnyAsync(notification => notification.IdNotification == idNotification);
    }
}