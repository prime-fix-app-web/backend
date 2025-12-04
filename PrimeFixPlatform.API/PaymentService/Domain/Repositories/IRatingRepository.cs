using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.PaymentService.Domain.Repositories;

public interface IRatingRepository: IBaseRepository<Rating>
{
    Task<bool> ExistsByIdRating(int ratingId);
    
    Task<bool> ExistsByIdAutoRepair(int autoRepairId);
    
    Task<bool> ExistsByIdAutoRepairAndIdRatingIsNot(int autoRepairId, int ratingId);
    
    Task<IEnumerable<Rating>> FindByIdAutoRepair(int autoRepairId);
    
}