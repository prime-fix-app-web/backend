using PrimeFixPlatform.API.PaymentService.Application.Internal.OutboundServices.ACL;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.PaymentService.Application.Internal.CommandServices;

/// <summary>
///     Command service for Payment aggregate
/// </summary>
/// <param name="paymentRepository">
///     The payment repository
/// </param>
/// <param name="iamServiceFromPaymentService">
///     The IAM service from payment service
/// </param>
/// <param name="unitOfWork">
///     Unit of work for the payment management
/// </param>
public class PaymentCommandService(
    IPaymentRepository paymentRepository,
    IExternalIamServiceFromPaymentService iamServiceFromPaymentService,
    IUnitOfWork unitOfWork)
: IPaymentCommandService
{
    /// <summary>
    ///     Handles the command to create a new Payment
    /// </summary>
    /// <param name="command">
    ///     The command to create a new vehicle
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created payment.
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user account does not exist in the IAM service
    /// </exception>
    public async Task<int> Handle(CreatePaymentCommand command)
    {
        var userAccountId = command.UserAccountId;
        
        // Verify that the user account exists in the IAM service
        if (!await iamServiceFromPaymentService.ExistsUserAccountByIdAsync(userAccountId))
            throw new NotFoundArgumentException("UserAccount with id " + userAccountId + " does not exist in IAM Service");
        
        var payment = new Payment(command);
        await paymentRepository.AddAsync(payment);
        await unitOfWork.CompleteAsync();
        return payment.PaymentId;
    }

    /// <summary>
    ///     Handles the command to update an existing payment
    /// </summary>
    /// <param name="command"></param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated payment.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a payment with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the payment to update was not found
    /// </exception>
    public async Task<Payment?> Handle(UpdatePaymentCommand command)
    {
        var paymentId = command.PaymentId;
        var userAccountId = command.UserAccountId;
        
        // Verify that the payment exists
        if(!await paymentRepository.ExistsByIdPayment(paymentId))
            throw new NotFoundIdException("Payment with the same id "+paymentId+" does not exist");
        
        // Verify that the user account exists in the IAM service
        if (!await iamServiceFromPaymentService.ExistsUserAccountByIdAsync(userAccountId))
            throw new NotFoundArgumentException("UserAccount with id " + userAccountId + " does not exist in IAM Service");
        
        var paymentToUpdate = await paymentRepository.FindByIdAsync(paymentId);
        if (paymentToUpdate is null)
            throw new NotFoundArgumentException("Payment not found");
        paymentToUpdate.UpdatePayment(command);
        paymentRepository.Update(paymentToUpdate);
        await unitOfWork.CompleteAsync();
        return paymentToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete an existing payment
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing payment
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the payment was successfully deleted.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a payment with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the payment to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeletePaymentCommand command)
    {
        if (!await paymentRepository.ExistsByIdPayment(command.PaymentId))
            throw new NotFoundIdException("Payment with id " + command.PaymentId  + " does not exist");
        var payment = await paymentRepository.FindByIdAsync(command.PaymentId);
        if (payment is null)
            throw new NotFoundArgumentException("Payment not found");
        paymentRepository.Remove(payment);
        await unitOfWork.CompleteAsync();
        return true;
    }
}