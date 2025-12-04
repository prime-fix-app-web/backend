using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between TechnicianSchedule-related requests, commands, and responses.
/// </summary>
public static class TechnicianScheduleAssembler
{
    /// <summary>
    ///     Converts a CreateTechnicianScheduleRequest to a CreateTechnicianScheduleCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateTechnicianScheduleRequest containing technician schedule details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateTechnicianScheduleCommand.
    /// </returns>
    public static CreateTechnicianScheduleCommand ToCommandFromRequest(CreateTechnicianScheduleRequest request)
    {
        return new CreateTechnicianScheduleCommand(
            request.TechnicianId, 
            request.DayOfWeek, request.StartTime, request.EndTime,
            request.IsActive
        );
    }
    
    /// <summary>
    ///     Converts an UpdateTechnicianScheduleRequest to an UpdateTechnicianScheduleCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateTechnicianScheduleRequest containing updated technician schedule details.
    /// </param>
    /// <param name="idSchedule">
    ///     The identifier of the technician schedule to be updated.
    /// </param>
    /// <returns></returns>
    public static UpdateTechnicianScheduleCommand ToCommandFromRequest(UpdateTechnicianScheduleRequest request, int idSchedule)
    {
        return new UpdateTechnicianScheduleCommand(
            idSchedule, request.TechnicianId, 
            request.DayOfWeek, request.StartTime, request.EndTime,
            request.IsActive
        );
    }

    /// <summary>
    ///     Converts a TechnicianSchedule entity to a TechnicianScheduleResponse.
    /// </summary>
    /// <param name="entity">
    ///     The TechnicianSchedule entity containing technician schedule details.
    /// </param>
    /// <returns>
    ///     The corresponding TechnicianScheduleResponse.
    /// </returns>
    public static TechnicianScheduleResponse ToResponseFromEntity(TechnicianSchedule entity)
    {
        return new TechnicianScheduleResponse(
            entity.ScheduleId, entity.TechnicianId, 
            entity.DayOfWeek, entity.StartTime, entity.EndTime,
            entity.IsActive
        );
    }
}