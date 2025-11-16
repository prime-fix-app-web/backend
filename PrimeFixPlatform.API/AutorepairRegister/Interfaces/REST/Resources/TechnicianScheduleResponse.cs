using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

/// <summary>
///     Response for a technician schedule
/// </summary>
/// <param name="IdSchedule">
///     The unique identifier of the technician schedule
/// </param>
/// <param name="IdTechnician">
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
    [property: JsonPropertyName("id_schedule")] string IdSchedule,
    [property: JsonPropertyName("id_technician")] string IdTechnician,
    [property: JsonPropertyName("day_of_week")] string DayOfWeek,
    [property: JsonPropertyName("start_time")] TimeOnly  StartTime,
    [property: JsonPropertyName("end_time")] TimeOnly EndTime,
    [property: JsonPropertyName("is_active")] bool IsActive);