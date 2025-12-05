using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.QueryServices;

/// <summary>
///     Query service for managing AutoRepair entities.
/// </summary>
/// <param name="autoRepairRepository">
///     The auto repair repository.
/// </param>
public class AutoRepairQueryService(IAutoRepairRepository autoRepairRepository, ILogger<AutoRepairQueryService> logger)
: IAutoRepairQueryService
{
    /// <summary>
    ///     Retrieves all <see cref="AutoRepair"/> entities along with their associated <see cref="ServiceOffer"/>s
    ///     and registers these offers in each AutoRepair's <see cref="ServiceCatalog"/>.
    /// </summary>
    /// <param name="query">
    ///     The query object to retrieve all auto repairs.
    /// </param>
    /// <returns>
    ///     A collection of <see cref="AutoRepair"/> entities with fully populated <see cref="ServiceCatalog"/>s.
    /// </returns>
    public async Task<IEnumerable<AutoRepair>> Handle(GetAllAutoRepairsQuery query)
    {
        var autoRepairs = await autoRepairRepository.LisWithServiceOffersAsync();

        foreach (var ar in autoRepairs)
        {
            foreach (var offer in ar.ServiceOffers)
            {
                ar.ServiceCatalog.AddServiceOffer(
                    offer.AutoRepair,
                    offer.Service,
                    offer.Price,
                    offer.IsActive,
                    offer.DurationHours
                );
            }
        }

        return autoRepairs;
    }

    /// <summary>
    ///     Handles the retrieval of an auto repair by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to get an auto repair by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the AutoRepair entity if found; otherwise, throws NotFoundIdException.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that an auto repair with the specified ID was not found.
    /// </exception>
    public async Task<AutoRepair?> Handle(GetAutoRepairByIdQuery query)
    {
        return await autoRepairRepository.FindByIdAsync(query.AutoRepairId)
            ?? throw new NotFoundIdException("AutoRepair with the id " + query.AutoRepairId + " was not found.");
    }

    public async Task<ServiceOffer?> Handle(GetServiceOfferByServiceIdAndAutoRepairIdQuery query)
    {
        return await autoRepairRepository
            .FindServiceOfferByServiceIdAndAutoRepairIdAsync(
                query.ServiceId,
                query.AutoRepairId
            );
    }
    
    /// <summary>
    ///     Retrieves an <see cref="AutoRepair"/> along with its associated <see cref="ServiceOffer"/>s
    ///     and registers these offers in the AutoRepair's <see cref="ServiceCatalog"/>.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The unique identifier of the AutoRepair to retrieve.
    /// </param>
    /// <returns>
    ///     The <see cref="AutoRepair"/> with its <see cref="ServiceCatalog"/> fully populated with ServiceOffers.
    /// </returns>
    /// <exception cref="KeyNotFoundException">
    ///     Thrown if no AutoRepair with the specified ID is found.
    /// </exception>
    public async Task<AutoRepair> GetByIdAsync(int autoRepairId)
    {
        var autoRepair = await autoRepairRepository.FindByIdWithServiceOffersAsync(autoRepairId);
        if (autoRepair == null)
        {
            throw new KeyNotFoundException($"AutoRepair with id {autoRepairId} was not found");
        }

        foreach (var offer in autoRepair.ServiceOffers)
        {
            autoRepair.ServiceCatalog.AddServiceOffer(
                offer.AutoRepair,
                offer.Service,
                offer.Price,
                offer.IsActive,
                offer.DurationHours
            );
        }

        return autoRepair;
    }
    
}