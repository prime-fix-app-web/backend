namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to update an existing Notification
/// </summary>
/// <param name="NotificationId">
///     The unique identifier for the notification to be updated
/// </param>
/// <param name="Message">
///     The message content of the notification to be updated
/// </param>
/// <param name="Read">
///     The read status of the notification to be updated
/// </param>
/// <param name="VehicleId">
///     The unique identifier of the vehicle associated with the notification to be updated
/// </param>
/// <param name="Sent">
///     The date the notification was sent
/// </param>
public record UpdateNotificationCommand(int NotificationId, string Message, bool Read, 
    int VehicleId, DateOnly Sent);