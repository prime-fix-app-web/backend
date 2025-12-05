namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to create a new Notification
/// </summary>
/// <param name="Message">
///     The message content of the notification to be created
/// </param>
/// <param name="Read">
///     The read status of the notification to be created
/// </param>
/// <param name="VehicleId">
///     The unique identifier of the vehicle associated with the notification to be created
/// </param>
/// <param name="Sent">
///     The date the notification was sent
/// </param>
public record CreateNotificationCommand( string Message, bool Read, 
    int VehicleId, DateOnly Sent);