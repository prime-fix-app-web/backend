using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.PaymentService.Interfaces.ACL;

namespace PrimeFixPlatform.API.PaymentService.Application.ACL;

/// <summary>
///     Facade for PaymentService context
/// </summary>
/// <param name="paymentCommandService">
///     The payment command service
/// </param>
/// <param name="paymentQueryService">
///     The payment query service
/// </param>
public class PaymentServiceContextFacade(
    IPaymentCommandService paymentCommandService,
    IPaymentQueryService paymentQueryService
    ): IPaymentServiceContextFacade
{
    
    /// <summary>
    ///     Creates a new payment
    /// </summary>
    /// <param name="cardNumber">The card number.</param>
    /// <param name="cardType">The card type.</param>
    /// <param name="month">The month of expiring.</param>
    /// <param name="year">The year of expiring.</param>
    /// <param name="cvv">The cvv number.</param>
    /// <param name="userAccountId">The user account id related</param>
    /// <returns>
    ///     The payment ID if created.
    /// </returns>
    public async Task<int> CreatePayment(string cardNumber, string cardType, int month, int year, int cvv, int userAccountId)
    {
        var createPaymentCommand = 
            new CreatePaymentCommand(cardNumber, new CardType(cardType), month, year, cvv, userAccountId);
        var paymentId = await paymentCommandService.Handle(createPaymentCommand);
        
        return paymentId;
    }

    /// <summary>
    ///     Checks if the payment exits by its ID
    /// </summary>
    /// <param name="paymentId">The unique identifier of the payment</param>
    /// <returns>
    ///     Returns "true" if the payment exits, otherwise "false".
    /// </returns>
    public async Task<bool> ExistsPaymentById(int paymentId)
    {
        var getPaymentByIdQuery = new GetPaymentByIdQuery(paymentId);
        var payment = await paymentQueryService.Handle(getPaymentByIdQuery);
        return payment != null;
    }
}