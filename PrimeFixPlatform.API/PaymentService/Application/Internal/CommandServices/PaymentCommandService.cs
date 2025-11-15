using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.PaymentService.Application.Internal.CommandServices;

public class PaymentCommandService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
: IPaymentCommandService
{
    public async Task<string> Handle(CreatePaymentCommand command)
    {
        var idPayment = command.IdPayment;
        var idUserAccount = command.IdUserAccount;
        
        if(await paymentRepository.ExistsByIdPayment(idPayment))
            throw new NotFoundIdException("Payment with the same id "+idPayment+" already exists");
        
        if(await paymentRepository.ExistsByIdUserAccount(idUserAccount))
            throw new ConflictException("Payment with the same user account id " + idUserAccount + " already exists");

        var payment = new Payment(command);
        await paymentRepository.AddAsync(payment);
        await unitOfWork.CompleteAsync();
        return payment.IdPayment;
    }

    public async Task<Payment?> Handle(UpdatePaymentCommand command)
    {
        var idPayment = command.IdPayment;
        var idUserAccount = command.IdUserAccount;
        
        if(!await paymentRepository.ExistsByIdPayment(idPayment))
            throw new NotFoundIdException("Payment with the same id "+idPayment+" does not exist");
        
        if(await paymentRepository.ExistsByIdUserAccounAndIdPaymentIsNot(idUserAccount,idPayment))
            throw new ConflictException("Payment with the same user account id " + idUserAccount + " already exists");

        var paymentToUpdate = await paymentRepository.FindByIdAsync(idPayment);
        if (paymentToUpdate is null)
            throw new NotFoundArgumentException("Payment not found");
        paymentRepository.Update(paymentToUpdate);
        await unitOfWork.CompleteAsync();
        return paymentToUpdate;
    }

    public async Task<bool> Handle(DeletePaymentCommand command)
    {
        if (!await paymentRepository.ExistsByIdPayment(command.IdPayment))
            throw new NotFoundIdException("Payment with id " + command.IdPayment  + " does not exist");
        var payment = await paymentRepository.FindByIdAsync(command.IdPayment);
        if (payment is null)
            throw new NotFoundArgumentException("Payment not found");
        paymentRepository.Remove(payment);
        await unitOfWork.CompleteAsync();
        return true;
    }
}