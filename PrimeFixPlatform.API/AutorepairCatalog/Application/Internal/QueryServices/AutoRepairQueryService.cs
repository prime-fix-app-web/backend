using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
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
public class AutoRepairQueryService(IAutoRepairRepository autoRepairRepository)
: IAutoRepairQueryService
{
    /// <summary>
    ///     Handles the retrieval of all auto repairs.
    /// </summary>
    /// <param name="query">
    ///     The query to get all auto repairs.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of all AutoRepair entities.
    /// </returns>
    public async Task<IEnumerable<AutoRepair>> Handle(GetAllAutoRepairsQuery query)
    {
        return await autoRepairRepository.ListAsync();
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

    /// <summary>
    ///     Handles the check for the existence of an auto repair by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to check if an auto repair exists by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     true if the AutoRepair exists; otherwise, false.
    /// </returns>
    public async Task<bool> Handle(ExistsAutoRepairByIdQuery query)
    {
        return await autoRepairRepository.ExistsByAutoRepairId(query.AutoRepairId);
    }
}