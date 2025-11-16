using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;

namespace PrimeFixPlatform.API.PaymentService.Domain.Services;

public interface IRatingQueryService
{
    Task<IEnumerable<Rating>> Handle(GetAllRatingsQuery query);
    
    Task<Rating?> Handle(GetRatingByIdQuery query);
    
    Task<IEnumerable<Rating>> Handle(GetRatingByIdAutoRepairQuery query);
}