using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.PaymentService.Application.Internal.QueryServices;

/// <summary>
///     Query service for managing Payment entities
/// </summary>
/// <param name="paymentRepository">
///     The payment repository
/// </param>
public class PaymentQueryService(IPaymentRepository paymentRepository)
: IPaymentQueryService
{
    /// <summary>
    ///     Handles the retrieval of all payments.
    /// </summary>
    /// <param name="query">
    ///     The query to get all payments
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of all Payment entities.
    /// </returns>
    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await paymentRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the retrieval of a payment by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to get a payment by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the Payment entity if found; otherwise, throws NotFoundIdException.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a payment with the specified ID was not found.
    /// </exception>
    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await paymentRepository.FindByIdAsync(query.PaymentId)
            ?? throw new NotFoundIdException("Payment with the id " + query.PaymentId + " was not found.");
    }

    /// <summary>
    ///     Handles the retrieval of a payment by the user account id 
    /// </summary>
    /// <param name="query">
    ///     The query to get a payment by the user account ID.
    /// </param>
    /// <returns>
    ///      A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of Payment entities related to the user account ID.
    /// </returns>
    public async Task<IEnumerable<Payment>> Handle(GetPaymentByIdUserAccountQuery query)
    {
        return await paymentRepository.FindByIdUserAccount(query.UserAccountId);
    }
}