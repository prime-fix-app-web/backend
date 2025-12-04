using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

/// <summary>
///     Request to update a notification
/// </summary>
/// <param name="Message">
///     The message content of the notification to be updated.
/// </param>
/// <param name="Read">
///     The read status of the notification to be updated.
/// </param>
/// <param name="VehicleId">
///     The unique identifier of the vehicle associated with the notification to be updated.
/// </param>
/// <param name="Sent">
///     The date the notification was sent.
/// </param>
/// <param name="DiagnosticId">
///     The unique identifier of the diagnostic associated with the notification to be updated.
/// </param>
public record UpdateNotificationRequest(
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    string Message,
    
    [Required]
    bool Read,
    
    [property: JsonPropertyName("vehicle_id")]
    [Required]
    [MinLength(1)]
    int VehicleId,
    
    [Required]
    DateOnly Sent,
    
    [property: JsonPropertyName("diagnostic_id")]
    [Required]
    int DiagnosticId);