using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

/// <summary>
///     Response to get a notification
/// </summary>
/// <param name="Id">
///     The unique identifier of the notification.
/// </param>
/// <param name="Message">
///     The message content of the notification.
/// </param>
/// <param name="Read">
///     The read status of the notification.
/// </param>
/// <param name="VehicleId">
///     The unique identifier of the vehicle associated with the notification.
/// </param>
/// <param name="Sent">
///     The date the notification was sent.
/// </param>
public record NotificationResponse(
    int Id,
    string Message,
    bool Read,
    [property: JsonPropertyName("vehicle_id")] int VehicleId,
    DateOnly Sent);