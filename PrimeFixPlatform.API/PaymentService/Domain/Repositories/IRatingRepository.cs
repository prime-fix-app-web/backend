using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.PaymentService.Domain.Repositories;

public interface IRatingRepository: IBaseRepository<Rating>
{
    Task<bool> ExistsByIdRating(string idRating);
    
    Task<bool> ExistsByIdAutoRepair(string idAutoRepair);
    
    Task<bool> ExistsByIdAutoRepairAndIdRatingIsNot(string  idAutoRepair, string idRating);
    
    Task<IEnumerable<Rating>> FindByIdUserAccount(string idUserAccount);
    
    Task<IEnumerable<Rating>> FindByIdAutoRepair(string idAutoRepair);
    
}