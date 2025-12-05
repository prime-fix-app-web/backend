using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using Service = PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates.Service;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Assemblers;

/// <summary>
/// Assembler responsible for converting <see cref="ServiceOffer"/> domain entities
/// into <see cref="ServiceOfferResource"/> response resources.
/// </summary>
public class ServiceOfferAssembler
{
    
    /// <summary>
    /// Converts a <see cref="ServiceOffer"/> domain entity into a
    /// <see cref="ServiceOfferResource"/> REST response resource.
    /// </summary>
    /// <param name="entity">
    /// Domain ServiceOffer entity to be converted.
    /// </param>
    /// <returns>
    /// A <see cref="ServiceOfferResource"/> representation of the entity.
    /// </returns>
    public static ServiceOfferResource ToResponseFromEntity(ServiceOffer entity)
    {
        return new ServiceOfferResource(
            entity.ServiceId,
            entity.Price,
            entity.DurationHours,
            entity.IsActive
        );
    }
}