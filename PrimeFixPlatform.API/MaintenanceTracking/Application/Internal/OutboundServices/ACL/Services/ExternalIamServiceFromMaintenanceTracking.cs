using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.IAM.Interfaces.ACL;

namespace PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.OutboundServices.ACL.Services;

/// <summary>
///     External IAM service used by Maintenance Tracking module to interact with IAM module
/// </summary>
/// <param name="iamContextFacade">
///     The IAM context facade to interact with IAM module
/// </param>
public class ExternalIamServiceFromMaintenanceTracking
(IIamContextFacade iamContextFacade) : IExternalIamServiceFromMaintenanceTracking
{
    /// <summary>
    ///     Checks if a user exists by user id
    /// </summary>
    /// <param name="userId">
    ///     The user id to check
    /// </param>
    /// <returns>
    ///     A boolean indicating whether the user exists
    /// </returns>
    public async Task<bool> ExistsUserByIdAsync(int userId)
    {
        return await iamContextFacade.ExistsUserAccountById(userId);
    }

    /// <summary>
    ///     Fetches the role of a user by user id
    /// </summary>
    /// <param name="userId">
    ///     The user id to fetch the role for
    /// </param>
    /// <returns>
    ///     A role enum representing the user's role
    /// </returns>
    public async Task<ERole> FetchRoleByUserId(int userId)
    {
        return await iamContextFacade.FetchRoleByUserId(userId);
    }
}