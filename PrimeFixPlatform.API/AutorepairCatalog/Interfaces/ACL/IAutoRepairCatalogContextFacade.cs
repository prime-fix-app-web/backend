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

   
    Task<int> CreateAutoRepairAsync(string contactEmail, string ruc, int userAccountId);
}