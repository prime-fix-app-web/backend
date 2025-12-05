using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing AutoRepair entities.
/// </summary>
public interface IAutoRepairRepository : IBaseRepository<AutoRepair>
{
    /// <summary>
    ///     Checks if an AutoRepair entity exists by its unique identifier.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The unique identifier of the AutoRepair entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether the AutoRepair entity exists.
    /// </returns>
    Task<bool> ExistsByAutoRepairId(int autoRepairId);
    
    /// <summary>
    ///     Checks if an AutoRepair entity exists by its RUC.
    /// </summary>
    /// <param name="ruc">
    ///     The RUC of the AutoRepair entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether the AutoRepair entity exists.
    /// </returns>
    Task<bool> ExistsByRuc(string ruc);
    
    /// <summary>
    ///     Checks if an AutoRepair entity exists by its RUC, excluding a specific AutoRepair ID.
    /// </summary>
    /// <param name="ruc">
    ///     The RUC of the AutoRepair entity.
    /// </param>
    /// <param name="autoRepairId">
    ///     The unique identifier of the AutoRepair entity to exclude.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether the AutoRepair entity exists.
    /// </returns>
    Task<bool> ExistsByRucAndAutoRepairIdIsNot(string ruc, int autoRepairId);
    
    /// <summary>
    ///     Checks if an AutoRepair entity exists by its contact email.
    /// </summary>
    /// <param name="contactEmail">
    ///     The contact email of the AutoRepair entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether the AutoRepair entity exists.
    /// </returns>
    Task<bool> ExistsByContactEmail(string contactEmail);
    
    /// <summary>
    ///     Checks if an AutoRepair entity exists by its contact email, excluding a specific AutoRepair ID.
    /// </summary>
    /// <param name="contactEmail">
    ///     The contact email of the AutoRepair entity.
    /// </param>
    /// <param name="autoRepairId">
    ///     The unique identifier of the AutoRepair entity to exclude.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether the AutoRepair entity exists.
    /// </returns>
    Task<bool> ExistsByContactEmailAndAutoRepairIdIsNot(string contactEmail, int autoRepairId);
    
    
    Task<ServiceOffer?> FindServiceOfferByServiceIdAndAutoRepairIdAsync(int queryServiceId, int queryAutoRepairId);
    Task<AutoRepair?> FindByIdWithServiceOffersAsync(int autoRepairId);
    Task<List<AutoRepair>> LisWithServiceOffersAsync();
}