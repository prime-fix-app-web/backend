using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

/// <summary>
///     Response for a technician schedule
/// </summary>
/// <param name="ScheduleId">
///     The unique identifier of the technician schedule
/// </param>
/// <param name="TechnicianId">
///     The unique identifier of the technician
/// </param>
/// <param name="DayOfWeek">
///     The day of the week for the schedule
/// </param>
/// <param name="StartTime">
///     The start time of the schedule
/// </param>
/// <param name="EndTime">
///     The end time of the schedule
/// </param>
/// <param name="IsActive">
///     Flag indicating if the schedule is active
/// </param>
public record TechnicianScheduleResponse(
    [property: JsonPropertyName("schedule_id")] int ScheduleId,
    [property: JsonPropertyName("technician_id")] int TechnicianId,
    [property: JsonPropertyName("day_of_week")] string DayOfWeek,
    [property: JsonPropertyName("start_time")] TimeOnly  StartTime,
    [property: JsonPropertyName("end_time")] TimeOnly EndTime,
    [property: JsonPropertyName("is_active")] bool IsActive);