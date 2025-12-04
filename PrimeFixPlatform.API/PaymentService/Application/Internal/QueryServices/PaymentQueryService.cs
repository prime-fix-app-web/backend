using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.PaymentService.Application.Internal.QueryServices;

public class PaymentQueryService(IPaymentRepository paymentRepository)
: IPaymentQueryService
{
    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await paymentRepository.ListAsync();
    }

    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await paymentRepository.FindByIdAsync(query.PaymentId)
            ?? throw new NotFoundIdException("Payment with the id " + query.PaymentId + " was not found.");
    }

    public async Task<IEnumerable<Payment>> Handle(GetPaymentByIdUserAccountQuery query)
    {
        return await paymentRepository.FindByIdUserAccount(query.UserAccountId);
    }
}