using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;

namespace PrimeFixPlatform.API.PaymentService.Domain.Services;

/// <summary>
///     Represents a repository interface for handling payment queries.
/// </summary>
public interface IPaymentQueryService
{
    /// <summary>
    ///     Handles the GetAllPaymentsQuery to retrieve all payments.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving payments.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable of payments.
    /// </returns>
    Task<IEnumerable<Payment>>  Handle(GetAllPaymentsQuery query);
    
    /// <summary>
    ///     Handles the GetPaymentByIdQuery to retrieve a payment by its ID.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the payment to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the payment if found; otherwise, null.
    /// </returns>
    Task<Payment?> Handle(GetPaymentByIdQuery query);
    
    /// <summary>
    ///     Handles the GetPaymentByIdUserAccountQuery to retrieve a payment by a user account id.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the user account related to the payment to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable of payments.
    /// </returns>
    Task<IEnumerable<Payment>> Handle(GetPaymentByIdUserAccountQuery query);
}