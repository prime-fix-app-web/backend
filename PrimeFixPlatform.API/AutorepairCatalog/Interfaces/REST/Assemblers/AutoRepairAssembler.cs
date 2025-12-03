using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between AutoRepair-related requests, commands, and responses.
/// </summary>
public class AutoRepairAssembler
{
    /// <summary>
    ///     Converts a CreateAutoRepairRequest to a CreateAutoRepairCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateAutoRepairRequest containing auto repair details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateAutoRepairCommand.
    /// </returns>
    public static CreateAutoRepairCommand ToCommandFromRequest(CreateAutoRepairRequest request)
    {
        return new CreateAutoRepairCommand(
            request.IdAutoRepair, request.Ruc, request.ContactEmail,
            request.TechniciansCount, request.IdUserAccount
        );
    }
    
    /// <summary>
    ///     Converts an UpdateAutoRepairRequest to an UpdateAutoRepairCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateAutoRepairRequest containing updated auto repair details.
    /// </param>
    /// <param name="idAutoRepair">
    ///     The identifier of the auto repair to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateAutoRepairCommand.
    /// </returns>
    public static UpdateAutoRepairCommand ToCommandFromRequest(UpdateAutoRepairRequest request, int idAutoRepair)
    {
        return new UpdateAutoRepairCommand(
            idAutoRepair, request.Ruc, request.ContactEmail,
            request.TechniciansCount, request.IdUserAccount
        );
    }
    
    /// <summary>
    ///     Converts an AutoRepair entity to an AutoRepairResponse.
    /// </summary>
    /// <param name="entity">
    ///     The AutoRepair entity containing auto repair details.
    /// </param>
    /// <returns>
    ///     The corresponding AutoRepairResponse.
    /// </returns>
    public static AutoRepairResponse ToResponseFromEntity(AutoRepair entity)
    {
        return new AutoRepairResponse(
            entity.IdAutoRepair, entity.Ruc, entity.ContactEmail,
            entity.TechniciansCount, entity.IdUserAccount
        );
    }
}