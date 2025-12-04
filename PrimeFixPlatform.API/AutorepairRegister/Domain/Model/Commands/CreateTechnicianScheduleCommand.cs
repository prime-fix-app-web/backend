namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

/// <summary>
///     Command to create a new Technician Schedule
/// </summary>
/// <param name="IdSchedule">
///     The unique identifier for the schedule to be created
/// </param>
/// <param name="IdTechnician">
///     The unique identifier for the technician
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
public record CreateTechnicianScheduleCommand( int TechnicianId, string DayOfWeek, TimeOnly StartTime, TimeOnly EndTime, bool IsActive);