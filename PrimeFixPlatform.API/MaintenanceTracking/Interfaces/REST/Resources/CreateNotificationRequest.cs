using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

/// <summary>
///     Request to create a notification
/// </summary>
/// <param name="Message">
///     The message content of the notification to be created.
/// </param>
/// <param name="Read">
///     The read status of the notification to be created.
/// </param>
/// <param name="VehicleId">
///     The unique identifier of the vehicle associated with the notification to be created.
/// </param>
/// <param name="Sent">
///     The date the notification was sent.
/// </param>
public record CreateNotificationRequest(
    
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    string Message,
    
    [property: JsonPropertyName("vehicle_id")]
    [Required]
    int VehicleId,
    
    [Required]
    DateOnly Sent);