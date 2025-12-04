namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

/// <summary>
///     Command to delete a Technician Schedule
/// </summary>
/// <param name="TechnicianScheduleId">
///     The unique identifier for the schedule to be deleted
/// </param>
public record DeleteTechnicianScheduleCommand(int TechnicianScheduleId);