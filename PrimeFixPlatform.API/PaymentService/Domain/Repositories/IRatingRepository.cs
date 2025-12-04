using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.PaymentService.Domain.Repositories;

public interface IRatingRepository: IBaseRepository<Rating>
{
    /// <summary>
    ///     Checks if a rating exists by its unique identifier
    /// </summary>
    /// <param name="idRating">
    ///     The unique identifier of the rating
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a rating with the specified ID exists. 
    /// </returns>
    Task<bool> ExistsByIdRating(string idRating);
    
    /// <summary>
    ///     Check if a rating exists by an autorepair associated.
    /// </summary>
    /// <param name="idAutoRepair">
    ///     The unique identifier of the autorepair to check
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a rating with the specified autorepair exists.
    /// </returns>
    Task<bool> ExistsByIdAutoRepair(IdAutoRepair idAutoRepair);
    
    /// <summary>
    ///     Checks if a rating exists by an autorepair associated, excluding a specific rating by its ID 
    /// </summary>
    /// <param name="idAutoRepair">
    ///     The unique identifier of the autorepair to check
    /// </param>
    /// <param name="idRating">
    ///     The unique identifier of the rating to exclude from the check
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a rating with the specified autorepair associated exists,
    ///     excluding the rating with the specified ID.
    /// </returns>
    Task<bool> ExistsByIdAutoRepairAndIdRatingIsNot(IdAutoRepair  idAutoRepair, string idRating);
    
    Task<IEnumerable<Rating>> FindByIdAutoRepair(IdAutoRepair idAutoRepair);
    
}