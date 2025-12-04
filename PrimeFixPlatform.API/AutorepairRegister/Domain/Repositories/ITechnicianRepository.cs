using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing Technician entities.
/// </summary>
public interface ITechnicianRepository : IBaseRepository<Technician>
{
    /// <summary>
    ///     Checks if a Technician entity exists by its unique identifier.
    /// </summary>
    /// <param name="technicianId">
    ///     The unique identifier of the Technician entity.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether the Technician entity exists.
    /// </returns>
    Task<bool> ExistsByIdTechnician(int technicianId);
}