namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Queries;

/// <summary>
///     Query to get a technician schedule by its identifier.
/// </summary>
/// <param name="IdSchedule">
///     The identifier of the technician schedule to retrieve.
/// </param>
public record GetTechnicianScheduleByIdQuery(int ScheduleId);