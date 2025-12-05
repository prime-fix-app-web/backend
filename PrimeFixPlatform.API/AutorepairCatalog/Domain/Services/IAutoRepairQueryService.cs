using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;

/// <summary>
///     Represents a repository interface for handling auto repair queries.
/// </summary>
public interface IAutoRepairQueryService
{
    /// <summary>
    ///     Handles the GetAllAutoRepairsQuery to retrieve all auto repairs.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving auto repairs.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable of auto repairs.
    /// </returns>
    Task<IEnumerable<AutoRepair>> Handle(GetAllAutoRepairsQuery query);
    
    /// <summary>
    ///     Handles the GetAutoRepairByIdQuery to retrieve an auto repair by its ID.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the auto repair to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the auto repair if found; otherwise, null.
    /// </returns>
    Task<AutoRepair?> Handle(GetAutoRepairByIdQuery query);
    
    Task<ServiceOffer?> Handle(GetServiceOfferByServiceIdAndAutoRepairIdQuery query);
    
    Task<AutoRepair> GetByIdAsync(int autoRepairId);
}