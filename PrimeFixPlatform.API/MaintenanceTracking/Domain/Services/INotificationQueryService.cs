using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;

/// <summary>
///     Represents a repository interface for handling notification queries.
/// </summary>
public interface INotificationQueryService
{
    /// <summary>
    ///     Handles the GetAllNotificationsQuery to retrieve all notifications.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving notifications.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable of notifications.
    /// </returns>
    Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query);
    
    /// <summary>
    ///     Handles the GetNotificationByIdQuery to retrieve a notification by its ID.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the notification to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the notification if found; otherwise, null.
    /// </returns>
    Task <Notification?> Handle(GetNotificationByIdQuery query);


    /// <summary>
    ///     Handles the ExistsNotificationByIdQuery to check if a notification exists by its ID.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the notification to check for existence.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean value indicating whether the notification exists.
    /// </returns>
    Task<bool> Handle(ExistsNotificationByIdQuery query);
}