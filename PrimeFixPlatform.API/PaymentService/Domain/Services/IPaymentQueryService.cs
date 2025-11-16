using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;

namespace PrimeFixPlatform.API.PaymentService.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Payment>>  Handle(GetAllPaymentsQuery query);
    
    Task<Payment?> Handle(GetPaymentByIdQuery query);
    
    Task<IEnumerable<Payment>> Handle(GetPaymentByIdUserAccountQuery query);
}