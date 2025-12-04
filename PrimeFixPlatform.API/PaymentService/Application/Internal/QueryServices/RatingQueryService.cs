using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.PaymentService.Application.Internal.QueryServices;

public class RatingQueryService(IRatingRepository ratingRepository)
: IRatingQueryService
{
    public async Task<IEnumerable<Rating>> Handle(GetAllRatingsQuery query)
    {
        return await ratingRepository.ListAsync();
    }

    public async Task<Rating?> Handle(GetRatingByIdQuery query)
    {
        return await ratingRepository.FindByIdAsync(query.RatingId)
            ?? throw new NotFoundIdException("Rating with the id " + query.RatingId + " was not found");
    }

    public async Task<IEnumerable<Rating>> Handle(GetRatingByIdAutoRepairQuery query)
    {
        return await ratingRepository.FindByIdAutoRepair(query.AutoRepairId);
    }
}