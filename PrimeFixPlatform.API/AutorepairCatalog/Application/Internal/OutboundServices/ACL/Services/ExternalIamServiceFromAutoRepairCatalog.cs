using PrimeFixPlatform.API.IAM.Interfaces.ACL;

namespace PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.OutboundServices.ACL.Services;

/// <summary>
///     External IAM service used by Auto Repair Catalog
/// </summary>
/// <param name="iamContextFacade">
///     The IAM context facade.
/// </param>
public class ExternalIamServiceFromAutoRepairCatalog(IIamContextFacade iamContextFacade) 
    : IExternalIamServiceFromAutoRepairCatalog
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
    public async Task<bool> ExistsUserAccountByIdAsync(int userAccountId)
    {
        return await iamContextFacade.ExistsUserAccountById(userAccountId);
    }
}