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
/// <param name="IdVehicle">
///     The unique identifier of the vehicle associated with the notification to be updated.
/// </param>
/// <param name="Sent">
///     The date the notification was sent.
/// </param>
/// <param name="IdDiagnostic">
///     The unique identifier of the diagnostic associated with the notification to be updated.
/// </param>
public record UpdateNotificationRequest(
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    string Message,
    
    [Required]
    bool Read,
    
    [property: JsonPropertyName("id_vehicle")]
    [Required]
    [MinLength(1)]
    string IdVehicle,
    
    [Required]
    DateOnly Sent,
    
    [property: JsonPropertyName("id_diagnostic")]
    [Required]
    [MinLength(1)]
    string IdDiagnostic);