namespace PrimeFixPlatform.API.PaymentService.Application.Internal.OutboundServices.ACL;

/// <summary>
///     Interface for external IAM service used by Payment Service
/// </summary>
public interface IExternalIamServiceFromPaymentService
{
    /// <summary>
    ///     Checks if a user exists by identifier asynchronously
    /// </summary>
    /// <param name="userId">
    ///     The user identifier
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation, containing true if user exists; otherwise, false
    /// </returns>
    Task<bool> ExistsUserAccountByIdAsync(int userId);
}