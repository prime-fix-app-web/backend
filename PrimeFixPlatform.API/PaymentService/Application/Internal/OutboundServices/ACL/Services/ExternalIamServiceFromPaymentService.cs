using PrimeFixPlatform.API.IAM.Interfaces.ACL;

namespace PrimeFixPlatform.API.PaymentService.Application.Internal.OutboundServices.ACL.Services;

/// <summary>
///     External IAM service used by Payment Service
/// </summary>
/// <param name="iamContextFacade">
///     The IAM context facade
/// </param>
public class ExternalIamServiceFromPaymentService 
(IIamContextFacade iamContextFacade)
    : IExternalIamServiceFromPaymentService
{
    /// <summary>
    ///     Checks if a user exists by identifier asynchronously
    /// </summary>
    /// <param name="userId">
    ///     The user identifier
    /// </param>
    /// <returns></returns>
    public async Task<bool> ExistsUserAccountByIdAsync(int userId)
    {
        return await iamContextFacade.ExistsUserAccountById(userId);
    }
}