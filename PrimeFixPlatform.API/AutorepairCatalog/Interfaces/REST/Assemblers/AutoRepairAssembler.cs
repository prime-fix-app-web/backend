using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.ValueObjects;
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
        return new CreateAutoRepairCommand(request.Ruc, request.ContactEmail,
            request.TechniciansCount, request.UserAccountId
        );
    }
    
    /// <summary>
    ///     Converts an UpdateAutoRepairRequest to an UpdateAutoRepairCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateAutoRepairRequest containing updated auto repair details.
    /// </param>
    /// <param name="autoRepairId">
    ///     The identifier of the auto repair to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateAutoRepairCommand.
    /// </returns>
    public static UpdateAutoRepairCommand ToCommandFromRequest(UpdateAutoRepairRequest request, int autoRepairId )
    {
        return new UpdateAutoRepairCommand(
            autoRepairId, request.Ruc, request.ContactEmail,
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
        var serviceOffers = entity.ServiceCatalog?.ServiceOffers
            .Select(so => new ServiceOfferResource(
                so.ServiceId,
                so.Price,
                so.DurationHours,
                so.IsActive
            ))
            .ToList() ?? new List<ServiceOfferResource>();
        
        return new AutoRepairResponse(
            entity.AutoRepairId, entity.Ruc, entity.ContactEmail,
            entity.TechniciansCount, entity.UserAccountId,
            serviceOffers
        );
    }
}