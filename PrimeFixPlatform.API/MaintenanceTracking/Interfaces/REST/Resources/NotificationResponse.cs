using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

/// <summary>
///     Response to get a notification
/// </summary>
/// <param name="IdNotification">
///     The unique identifier of the notification.
/// </param>
/// <param name="Message">
///     The message content of the notification.
/// </param>
/// <param name="Read">
///     The read status of the notification.
/// </param>
/// <param name="IdVehicle">
///     The unique identifier of the vehicle associated with the notification.
/// </param>
/// <param name="Sent">
///     The date the notification was sent.
/// </param>
/// <param name="IdDiagnostic">
///     The unique identifier of the diagnostic associated with the notification.
/// </param>
public record NotificationResponse(
    [property: JsonPropertyName("id_notification")] string IdNotification,
    string Message,
    bool Read,
    [property: JsonPropertyName("id_vehicle")] string IdVehicle,
    DateOnly Sent,
    
    [property: JsonPropertyName("id_diagnostic")] string IdDiagnostic);