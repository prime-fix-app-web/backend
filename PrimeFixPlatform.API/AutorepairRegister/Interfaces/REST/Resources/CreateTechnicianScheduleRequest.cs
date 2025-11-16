using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

/// <summary>
///     Request to create a technician schedule
/// </summary>
/// <param name="IdSchedule">
///     The unique identifier of the technician schedule to be created
/// </param>
/// <param name="IdTechnician">
///     The unique identifier of the technician for whom the schedule is being created
/// </param>
/// <param name="DayOfWeek">
///     The day of the week for the schedule to be created
/// </param>
/// <param name="StartTime">
///     The start time of the schedule to be created
/// </param>
/// <param name="EndTime">
///     The end time of the schedule to be created
/// </param>
/// <param name="IsActive">
///     Flag indicating if the schedule is active
/// </param>
public record CreateTechnicianScheduleRequest(
    [property: JsonPropertyName("id_schedule")]
    [Required]
    [MinLength(1)]
    string IdSchedule,
    
    [property: JsonPropertyName("id_technician")]
    [Required]
    [MinLength(1)]
    string IdTechnician,
    
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