using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Technician-related requests, commands, and responses.
/// </summary>
public static class TechnicianAssembler
{
    /// <summary>
    ///     Converts a CreateTechnicianRequest to a CreateTechnicianCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateTechnicianRequest containing technician details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateTechnicianCommand.
    /// </returns>
    public static CreateTechnicianCommand ToCommandFromRequest(CreateTechnicianRequest request)
    {
        return new CreateTechnicianCommand(
            request.Name, request.LastName, request.AutoRepairId
        );
    }
    
    /// <summary>
    ///     Converts an UpdateTechnicianRequest to an UpdateTechnicianCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateTechnicianRequest containing updated technician details.
    /// </param>
    /// <param name="technicianId">
    ///     The identifier of the technician to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateTechnicianCommand.
    /// </returns>
    public static UpdateTechnicianCommand ToCommandFromRequest(UpdateTechnicianRequest request, int technicianId)
    {
        return new UpdateTechnicianCommand(
            technicianId, request.Name, request.LastName, request.AutoRepairId
        );
    }
    
    /// <summary>
    ///     Converts a Technician entity to a TechnicianResponse.
    /// </summary>
    /// <param name="entity">
    ///     The Technician entity containing technician details.
    /// </param>
    /// <returns>
    ///     The corresponding TechnicianResponse.
    /// </returns>
    public static TechnicianResponse ToResponseFromEntity(Technician entity)
    {
        return new TechnicianResponse(
            entity.Id, entity.Name, entity.LastName, entity.AutoRepairId
        );
    }
}