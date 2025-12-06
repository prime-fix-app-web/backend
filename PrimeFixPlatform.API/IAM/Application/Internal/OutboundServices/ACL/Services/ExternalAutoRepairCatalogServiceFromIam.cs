using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.ACL;

namespace PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.ACL.Services;

/// <summary>
///     External Auto Repair Catalog service implementation for IAM.
/// </summary>
/// <param name="autoRepairCatalogContextFacade">
///     The <see cref="IAutoRepairCatalogContextFacade" /> to use.
/// </param>
public class ExternalAutoRepairCatalogServiceFromIam(IAutoRepairCatalogContextFacade autoRepairCatalogContextFacade)
    : IExternalAutoRepairCatalogServiceFromIam
{
    /// <summary>
    ///     Checks if an auto repair exists by its ID.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The ID of the auto repair to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains true if the auto repair exists; otherwise, false.
    /// </returns>
    public async Task<bool> ExistsAutoRepairByIdAsync(int autoRepairId)
    {
        return await autoRepairCatalogContextFacade.ExistsAutoRepairByIdAsync(autoRepairId);
    }

    /// <summary>
    ///     Creates a new auto repair.
    /// </summary>
    /// <param name="contactEmail">
    ///     The contact email for the auto repair.
    /// </param>
    /// <param name="ruc">
    ///     The RUC for the auto repair.
    /// </param>
    /// <param name="autoRepairId">
    ///     The ID of the auto repair.
    /// </param>
    /// <returns></returns>
    public async Task<int> CreateAutoRepairAsync(string contactEmail, string ruc, int autoRepairId)
    {
        return await autoRepairCatalogContextFacade.CreateAutoRepairAsync(contactEmail, ruc, autoRepairId);
    }

    /// <summary>
    ///     Deletes an auto repair by its ID.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The ID of the auto repair to delete.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    public async Task<bool> DeleteAutoRepairAsync(int autoRepairId)
    {
        return await autoRepairCatalogContextFacade.DeleteAutoRepairAsync(autoRepairId);
    }
}