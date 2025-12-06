namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;

/// <summary>
///     Query to check if a notification exists by its ID
/// </summary>
/// <param name="NotificationId">
///     The unique identifier of the notification to check for existence.
/// </param>
public record ExistsNotificationByIdQuery(int NotificationId);