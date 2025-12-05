namespace PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.OutboundServices.ACL;

/// <summary>
///     Interface for external IAM service used by Auto Repair Catalog
/// </summary>
public interface IExternalIamServiceFromAutoRepairCatalog
{
    /// <summary>
    ///     Checks if a user account exists by its ID.
    /// </summary>
    /// <param name="userAccountId">
    ///     The ID of the user account to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     true if the user account exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsUserAccountByIdAsync(int userAccountId);
}