using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

namespace PrimeFixPlatform.API.PaymentService.Domain.Services;

/// <summary>
///     Represents a service for handling payment-related commands.
/// </summary>
public interface IPaymentCommandService
{
    Task<int> Handle(CreatePaymentCommand command);
    
    Task<Payment?> Handle(UpdatePaymentCommand command);
    
    Task<bool> Handle(DeletePaymentCommand command);
}