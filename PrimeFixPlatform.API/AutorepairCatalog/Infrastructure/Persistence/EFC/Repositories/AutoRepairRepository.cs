using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
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
    public async Task<bool> ExistsByIdAutoRepair(string idAutoRepair)
    {
        return await Context.Set<AutoRepair>().AnyAsync(autoRepair => autoRepair.IdAutoRepair == idAutoRepair);
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
    public async Task<bool> ExistsByRucAndIdAutoRepairIsNot(string ruc, string idAutoRepair)
    {
        return await Context.Set<AutoRepair>().AnyAsync(autoRepair => autoRepair.Ruc == ruc && autoRepair.IdAutoRepair != idAutoRepair);
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
    public async Task<bool> ExistsByContactEmailAndIdAutoRepairIsNot(string contactEmail, string idAutoRepair)
    {
        return await Context.Set<AutoRepair>().AnyAsync(autoRepair => autoRepair.ContactEmail == contactEmail && autoRepair.IdAutoRepair != idAutoRepair);
    }
}