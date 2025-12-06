using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.OutboundServices.ACL;

/// <summary>
///     Interface for external IAM service from Maintenance Tracking
/// </summary>
public interface IExternalIamServiceFromMaintenanceTracking
{
    /// <summary>
    ///     Check if a user exists by user ID
    /// </summary>
    /// <param name="userId">
    ///     The user ID to check
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation, with a boolean indicating existence as result
    /// </returns>
    public Task<bool> ExistsUserByIdAsync(int userId);
    
    /// <summary>
    ///     Fetch role by user ID
    /// </summary>
    /// <param name="userId">
    ///     The user ID to fetch the role for
    /// </param>
    /// <returns>
    ///      The role of the user
    /// </returns>
    public Task<ERole> FetchRoleByUserId(int userId);
}