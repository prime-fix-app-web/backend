namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

/// <summary>
///     Command to update an existing Technician Schedule
/// </summary>
/// <param name="TechnicianScheduleId">
///     The unique identifier for the schedule to be updated
/// </param>
/// <param name="TechnicianId">
///     The unique identifier for the technician whose schedule is to be updated
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
public record UpdateTechnicianScheduleCommand(int TechnicianScheduleId, int TechnicianId, string DayOfWeek, TimeOnly StartTime, TimeOnly EndTime, bool IsActive);