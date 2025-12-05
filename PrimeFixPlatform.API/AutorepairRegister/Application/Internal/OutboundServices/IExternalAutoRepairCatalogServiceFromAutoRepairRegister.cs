namespace PrimeFixPlatform.API.AutorepairRegister.Application.Internal.OutboundServices;

/// <summary>
///     Interface for external Auto Repair Catalog service used by Auto Repair Register
/// </summary>
public interface IExternalAutoRepairCatalogServiceFromAutoRepairRegister
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
    public Task<bool> ExistsAutoRepairByIdAsync(int autoRepairId);
}