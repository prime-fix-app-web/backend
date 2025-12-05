using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.ACL;

namespace PrimeFixPlatform.API.AutorepairRegister.Application.Internal.OutboundServices.Services;

/// <summary>
///     External Auto Repair Catalog service used by Auto Repair Register
/// </summary>
/// <param name="autoRepairCatalogContextFacade">
///     The Auto Repair Catalog context facade.
/// </param>
public class ExternalAutoRepairCatalogServiceFromAutoRepairRegister
(IAutoRepairCatalogContextFacade autoRepairCatalogContextFacade) : IExternalAutoRepairCatalogServiceFromAutoRepairRegister
{
    /// <summary>
    ///     Checks if an auto repair exists by its ID.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The ID of the auto repair to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     true if the auto repair exists; otherwise, false.
    /// </returns>
    public Task<bool> ExistsAutoRepairByIdAsync(int autoRepairId)
    {
        return autoRepairCatalogContextFacade.ExistsAutoRepairByIdAsync(autoRepairId);
    }
}