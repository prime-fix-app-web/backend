using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.ACL;

/// <summary>
///     Facade for the PaymentService context
/// </summary>
public interface IPaymentServiceContextFacade
{
    /// <summary>
    /// Creates a payment.
    /// </summary>
    /// <param name="cardNumber">
    ///     Card number of the payment
    /// </param>
    /// <param name="cardType">
    ///     Card type of the payment
    /// </param>
    /// <param name="month">
    ///     Month of expiring of the payment
    /// </param>
    /// <param name="year">
    ///     Year of expiring of the payment
    /// </param>
    /// <param name="cvv">
    ///     CVV number of the payment
    /// </param>
    /// <param name="userAccountId">
    ///     User account id associated with the payment
    /// </param>
    /// <returns>
    /// The ID of the created payment, or 0 if creation failed.
    /// </returns>
    Task<int> CreatePayment(string cardNumber,
        CardType cardType,
        int month,
        int year,
        int cvv,
        int userAccountId);
    
    /// <summary>
    /// Checks if a payment exists by its ID.
    /// </summary>
    /// <para name="paymentId">
    ///     The id of hte payment to check
    /// </para>
    /// <returns>True if exists, otherwise false.</returns>
    Task<bool> ExistsPaymentById(int paymentId);
}