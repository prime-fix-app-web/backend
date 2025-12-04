using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.PaymentService.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    /// <summary>
    ///     Checks if a payment exists by its unique identifier
    /// </summary>
    /// <param name="paymentId">
    ///     The unique identifier of the payment
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a payment with the specified ID exists. 
    /// </returns>
    Task<bool> ExistsByIdPayment(int paymentId);
    
    /// <summary>
    ///     Checks if a payment exists by a user account associated.
    /// </summary>
    /// <param name="userAccountId">
    ///     The unique identifier of the user account to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a payment with the specified user account exists.
    /// </returns>
    Task<bool> ExistsByIdUserAccount(int userAccountId);
    
    /// <summary>
    ///     Checks if a payment exists by a user account associated, excluding a specific payment by its ID.
    /// </summary>
    /// <param name="userAccountId">
    ///     The unique identifier of the user account to check.
    /// </param>
    /// <param name="paymentId">
    ///     The unique identifier of the payment to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a payment with the specified user account associated exists,
    ///     excluding the payment with the specified ID.
    /// </returns>
    Task<bool> ExistsByIdUserAccountAndIdPaymentIsNot(int userAccountId, int paymentId);
    
    /// <summary>
    ///     Finds ratings by the user account associated.
    /// </summary>
    /// <param name="userAccountId">
    ///     The unique identifier of the user account to filter payments by.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of payments with the specified user account associated.
    /// </returns>
    Task<IEnumerable<Payment>> FindByIdUserAccount(int userAccountId);
}