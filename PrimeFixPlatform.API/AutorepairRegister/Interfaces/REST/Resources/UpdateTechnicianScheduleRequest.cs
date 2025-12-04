using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

/// <summary>
///     Request to update a technician schedule
/// </summary>
/// <param name="TechnicianId">
///     The unique identifier of the technician whose schedule is being updated
/// </param>
/// <param name="DayOfWeek">
///     The day of the week for the schedule to be updated
/// </param>
/// <param name="StartTime">
///     The start time of the schedule to be updated
/// </param>
/// <param name="EndTime">
///     The end time of the schedule to be updated
/// </param>
/// <param name="IsActive">
///     Flag indicating if the schedule is active
/// </param>
public record UpdateTechnicianScheduleRequest(
    [property: JsonPropertyName("technician_id")]
    [Required]
    [MinLength(1)]
    int TechnicianId,
    
    [property: JsonPropertyName("day_of_week")]
    [Required]
    [MaxLength(15)]
    string DayOfWeek,
    
    [property: JsonPropertyName("start_time")]
    [Required]
    TimeOnly  StartTime,
    
    [property: JsonPropertyName("end_time")]
    [Required]
    TimeOnly EndTime,
    
    [property: JsonPropertyName("is_active")]
    [Required]
    bool IsActive);