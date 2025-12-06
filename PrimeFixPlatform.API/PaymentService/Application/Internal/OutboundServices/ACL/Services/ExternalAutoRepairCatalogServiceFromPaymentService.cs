using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.ACL;

namespace PrimeFixPlatform.API.PaymentService.Application.Internal.OutboundServices.ACL.Services;

/// <summary>
///     External implementation of IAutoRepairCatalogService used by Payment Service
/// </summary>
/// <param name="autoRepairCatalogContextFacade">
///     The facade for accessing the Auto Repair Catalog context
/// </param>
public class ExternalAutoRepairCatalogServiceFromPaymentService 
    (IAutoRepairCatalogContextFacade autoRepairCatalogContextFacade)
    : IExternalAutoRepairCatalogServiceFromPaymentService
{
    /// <summary>
    ///     Checks if an auto repair exists by its ID
    /// </summary>
    /// <param name="autoRepairId">
    ///     The ID of the auto repair to check
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation, containing true if the auto repair exists, false otherwise
    /// </returns>
    public async Task<bool> ExistsAutoRepairByIdAsync(int autoRepairId)
    {
        return await autoRepairCatalogContextFacade.ExistsAutoRepairByIdAsync(autoRepairId);
    }
}