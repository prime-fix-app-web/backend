using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.AutorepairCatalog.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing AutoRepair entities.
/// </summary>
/// <param name="context">
///     The database context used for data access.
/// </param>
public class AutoRepairRepository(AppDbContext context)
: BaseRepository<AutoRepair>(context), IAutoRepairRepository
{
    /// <summary>
    ///     Checks if an AutoRepair entity exists by its unique identifier.
    /// </summary>
    /// <param name="idAutoRepair">
    ///     The unique identifier of the AutoRepair entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether an AutoRepair entity with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByIdAutoRepair(int idAutoRepair)
    {
        return await Context.Set<AutoRepair>().AnyAsync(autoRepair => autoRepair.AutoRepairId == idAutoRepair);
    }

    /// <summary>
    ///     Checks if an AutoRepair entity exists by its RUC
    /// </summary>
    /// <param name="ruc">
    ///     The RUC of the AutoRepair entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether an AutoRepair entity with the specified RUC exists.
    /// </returns>
    public async Task<bool> ExistsByRuc(string ruc)
    {
        return await Context.Set<AutoRepair>().AnyAsync(autoRepair => autoRepair.Ruc == ruc);
    }

    /// <summary>
    ///     Checks if an AutoRepair entity exists by its RUC excluding a specific AutoRepair ID
    /// </summary>
    /// <param name="ruc">
    ///     The RUC of the AutoRepair entity.
    /// </param>
    /// <param name="idAutoRepair">
    ///     The unique identifier of the AutoRepair entity to exclude.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether an AutoRepair entity with the specified RUC exists,
    ///     excluding the one with the specified AutoRepair ID.
    /// </returns>
    public async Task<bool> ExistsByRucAndIdAutoRepairIsNot(string ruc, int idAutoRepair)
    {
        return await Context.Set<AutoRepair>().AnyAsync(autoRepair => autoRepair.Ruc == ruc && autoRepair.AutoRepairId != idAutoRepair);
    }

    /// <summary>
    ///     Checks if an AutoRepair entity exists by its contact email.
    /// </summary>
    /// <param name="contactEmail">
    ///     The contact email of the AutoRepair entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether an AutoRepair entity with the specified contact email exists.
    /// </returns>
    public async Task<bool> ExistsByContactEmail(string contactEmail)
    {
        return await Context.Set<AutoRepair>().AnyAsync(autoRepair => autoRepair.ContactEmail == contactEmail);
    }

    /// <summary>
    ///     Checks if an AutoRepair entity exists by its contact email excluding a specific AutoRepair ID.
    /// </summary>
    /// <param name="contactEmail">
    ///     The contact email of the AutoRepair entity.
    /// </param>
    /// <param name="idAutoRepair">
    ///     The unique identifier of the AutoRepair entity to exclude.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether an AutoRepair entity with the specified contact email exists,
    ///     excluding the one with the specified AutoRepair ID.
    /// </returns>
    public async Task<bool> ExistsByContactEmailAndIdAutoRepairIsNot(string contactEmail, int idAutoRepair)
    {
        return await Context.Set<AutoRepair>().AnyAsync(autoRepair => autoRepair.ContactEmail == contactEmail && autoRepair.AutoRepairId != idAutoRepair);
    }

    /// <summary>
    ///     Retrieves a specific <see cref="ServiceOffer"/> associated with an
    ///     <see cref="AutoRepair"/> and a <see cref="Service"/> by their identifiers.
    /// </summary>
    /// <remarks>
    ///     This query loads the <see cref="ServiceCatalog"/> navigation property and its
    ///     related <see cref="ServiceOffer"/> collection in order to traverse the
    ///     aggregate and locate the requested offer.
    ///     
    ///     Internally, it performs a <c>SelectMany</c> over the
    ///     <see cref="ServiceCatalog.ServiceOffers"/> collection after filtering by
    ///     <see cref="AutoRepair.AutoRepairId"/>.
    ///     
    ///     Returns <c>null</c> when no matching service offer exists.
    /// </remarks>
    /// <param name="queryServiceId">
    ///     The identifier of the <see cref="Service"/> whose offer is being searched.
    /// </param>
    /// <param name="queryAutoRepairId">
    ///     The identifier of the <see cref="AutoRepair"/> that provides the service.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the matching <see cref="ServiceOffer"/> if found; otherwise, <c>null</c>.
    /// </returns>
    public async Task<ServiceOffer?> FindServiceOfferByServiceIdAndAutoRepairIdAsync(int queryServiceId, int queryAutoRepairId)
    {
        return await Context.Set<AutoRepair>()
            .Where(ar => ar.AutoRepairId == queryAutoRepairId)
            .SelectMany(ar => ar.ServiceOffers)
            .FirstOrDefaultAsync(so => so.ServiceId == queryServiceId);
    }

    public async Task<AutoRepair?> FindByIdWithServiceOffersAsync(int autoRepairId)
    {
        return await Context.Set<AutoRepair>()
            .Include(ar => ar.ServiceOffers)
            .ThenInclude(so => so.Service)
            .FirstOrDefaultAsync(ar => ar.AutoRepairId == autoRepairId);
    }

    public async Task<List<AutoRepair>> LisWithServiceOffersAsync()
    {
        return await Context.Set<AutoRepair>()
            .Include(ar => ar.ServiceOffers)
            .ThenInclude(so => so.Service) 
            .ToListAsync();
    }
}