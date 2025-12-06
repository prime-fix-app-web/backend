namespace PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.ACL;

/// <summary>
///     Interface for external Auto Repair Catalog Service used by IAM.
/// </summary>
public interface IExternalAutoRepairCatalogServiceFromIam
{
    /// <summary>
    ///     Checks if an Auto Repair exists by its ID.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The ID of the Auto Repair to check for existence.
    /// </param>
    /// <returns></returns>
    public Task<bool> ExistsAutoRepairByIdAsync(int autoRepairId);
    
    /// <summary>
    ///     Creates a new Auto Repair entry.
    /// </summary>
    /// <param name="contactEmail">
    ///     The contact email of the Auto Repair.
    /// </param>
    /// <param name="ruc">
    ///     The RUC of the Auto Repair.
    /// </param>
    /// <param name="autoRepairId">
    ///     The ID of the Auto Repair to be created.
    /// </param>
    /// <returns></returns>
    public Task<int> CreateAutoRepairAsync(string contactEmail, string ruc, int autoRepairId);
    
    /// <summary>
    ///     Deletes an Auto Repair by its ID.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The ID of the Auto Repair to be deleted.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    public Task<bool> DeleteAutoRepairAsync(int autoRepairId);
}