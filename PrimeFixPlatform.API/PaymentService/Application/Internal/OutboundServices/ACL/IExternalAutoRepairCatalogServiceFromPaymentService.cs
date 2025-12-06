namespace PrimeFixPlatform.API.PaymentService.Application.Internal.OutboundServices.ACL;

/// <summary>
///     In external interface for Auto Repair Catalog Service used by Payment Service
/// </summary>
public interface IExternalAutoRepairCatalogServiceFromPaymentService
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
    public Task<bool> ExistsAutoRepairByIdAsync(int autoRepairId);
}