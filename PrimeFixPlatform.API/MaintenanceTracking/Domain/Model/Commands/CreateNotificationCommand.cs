namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to create a new Notification
/// </summary>
/// <param name="IdNotification">
///     The unique identifier for the notification to be created
/// </param>
/// <param name="Message">
///     The message content of the notification to be created
/// </param>
/// <param name="Read">
///     The read status of the notification to be created
/// </param>
/// <param name="IdVehicle">
///     The unique identifier of the vehicle associated with the notification to be created
/// </param>
/// <param name="Sent">
///     The date the notification was sent
/// </param>
/// <param name="IdDiagnostic">
///     The unique identifier of the diagnostic associated with the notification to be created
/// </param>
public record CreateNotificationCommand(string IdNotification, string Message, bool Read, 
    string IdVehicle, DateOnly Sent, string IdDiagnostic);