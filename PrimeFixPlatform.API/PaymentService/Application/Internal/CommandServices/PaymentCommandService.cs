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
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class PaymentCommandService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
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
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a payment with the same id already exists
    /// </exception>
    public async Task<int> Handle(CreatePaymentCommand command)
    { 
        /*var idPayment = command.;*/
        
        /*if(await paymentRepository.ExistsByIdPayment(idPayment))
            throw new ConflictException("Payment with the same id "
                                        + idPayment + " already exists");
        */
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
        var idPayment = command.PaymentId;
        var idUserAccount = command.UserAccountId;
        
        if(!await paymentRepository.ExistsByIdPayment(idPayment))
            throw new NotFoundIdException("Payment with the same id "+idPayment+" does not exist");
        
        var paymentToUpdate = await paymentRepository.FindByIdAsync(idPayment);
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