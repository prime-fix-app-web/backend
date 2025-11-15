using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

namespace PrimeFixPlatform.API.PaymentService.Domain.Services;

/// <summary>
///     Represents a service for handling rating-related commands.
/// </summary>
public interface IRatingCommandService
{
    Task<string> Handle(CreateRatingCommand command);
    
    Task<Rating?> Handle(UpdateRatingCommand command);
    
    Task<bool> Handle(DeleteRatingCommand command);
}