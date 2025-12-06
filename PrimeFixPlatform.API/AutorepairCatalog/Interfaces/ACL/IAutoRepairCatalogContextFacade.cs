namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.ACL;

/// <summary>
///     Contract for Auto Repair Catalog Context Facade.
/// </summary>
public interface IAutoRepairCatalogContextFacade
{
    /// <summary>
    ///     Checks if an Auto Repair exists by its identifier.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The identifier of the Auto Repair to check.
    /// </param>
    /// <returns>
    ///     The task representing the asynchronous operation, containing true if the Auto Repair exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsAutoRepairByIdAsync(int autoRepairId);

    
    /// <summary>
    ///     Creates a new Auto Repair entry.
    /// </summary>
    /// <param name="contactEmail">
    ///     The contact email of the Auto Repair.
    /// </param>
    /// <param name="ruc">
    ///     The RUC of the Auto Repair.
    /// </param>
    /// <param name="userAccountId">
    ///     The user account identifier associated with the Auto Repair.
    /// </param>
    /// <returns></returns>
    Task<int> CreateAutoRepairAsync(string contactEmail, string ruc, int userAccountId);
    
    /// <summary>
    ///     Deletes an Auto Repair by its identifier.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The identifier of the Auto Repair to delete.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> DeleteAutoRepairAsync(int autoRepairId);
}