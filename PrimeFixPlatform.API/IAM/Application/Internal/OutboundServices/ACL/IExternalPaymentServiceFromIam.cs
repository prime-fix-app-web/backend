using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.ACL;

/// <summary>
///     Interface for external payment service from IAM.
/// </summary>
public interface IExternalPaymentServiceFromIam
{
    /// <summary>
    ///     Checks if a payment exists by its ID.
    /// </summary>
    /// <param name="paymentId">
    ///     The ID of the payment to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains true if the payment exists; otherwise, false.
    /// </returns>
    public Task<bool> ExistsPaymentByIdAsync(int paymentId);
    
    /// <summary>
    ///     Creates a new payment.
    /// </summary>
    /// <param name="cardNumber">
    ///     Card number for the payment.
    /// </param>
    /// <param name="cardType">
    ///     Card type for the payment.
    /// </param>
    /// <param name="month">
    ///     The expiration month of the card.
    /// </param>
    /// <param name="year">
    ///     The expiration year of the card.
    /// </param>
    /// <param name="ccv">
    ///     The CCV code of the card.
    /// </param>
    /// <param name="userAccountId">
    ///     The user account ID associated with the payment.
    /// </param>
    /// <returns></returns>
    public Task<int> CreatePaymentAsync(string cardNumber, CardType cardType, int month, int year, int ccv,
        int userAccountId);
}