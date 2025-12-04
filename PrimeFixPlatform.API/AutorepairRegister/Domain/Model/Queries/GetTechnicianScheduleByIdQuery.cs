namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Queries;

/// <summary>
///     Query to get a technician schedule by its identifier.
/// </summary>
/// <param name="TechnicianScheduleId">
///     The identifier of the technician schedule to retrieve.
/// </param>
public record GetTechnicianScheduleByIdQuery(int TechnicianScheduleId);