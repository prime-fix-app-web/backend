namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to update an existing Notification
/// </summary>
/// <param name="IdNotification">
///     The unique identifier for the notification to be updated
/// </param>
/// <param name="Message">
///     The message content of the notification to be updated
/// </param>
/// <param name="Read">
///     The read status of the notification to be updated
/// </param>
/// <param name="IdVehicle">
///     The unique identifier of the vehicle associated with the notification to be updated
/// </param>
/// <param name="Sent">
///     The date the notification was sent
/// </param>
/// <param name="IdDiagnostic">
///     The unique identifier of the diagnostic associated with the notification to be updated
/// </param>
public record UpdateNotificationCommand(string IdNotification, string Message, bool Read, 
    string IdVehicle, DateOnly Sent, string IdDiagnostic);