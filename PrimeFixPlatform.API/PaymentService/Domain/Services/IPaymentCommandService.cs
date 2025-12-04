using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

namespace PrimeFixPlatform.API.PaymentService.Domain.Services;

/// <summary>
///     Represents a service for handling payment-related commands.
/// </summary>
public interface IPaymentCommandService
{
    /// <summary>
    ///     Handles the creating of a new payment
    /// </summary>
    /// <param name="command">
    ///     The command containing payment creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created Payment entity, or null if creation failed.
    /// </returns>
    Task<int> Handle(CreatePaymentCommand command);
    
    /// <summary>
    ///     Handles the update of an existing payment.
    /// </summary>
    /// <param name="command">
    ///     The command containing payment update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated Payment entity, or null if the payment was not found.
    /// </returns>
    Task<Payment?> Handle(UpdatePaymentCommand command);
    
    /// <summary>
    ///     Handles the deletion of a payment.
    /// </summary>
    /// <param name="command">
    ///     The command containing payment deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeletePaymentCommand command);
}