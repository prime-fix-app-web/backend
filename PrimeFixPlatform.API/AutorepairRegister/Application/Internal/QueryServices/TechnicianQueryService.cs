using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairRegister.Application.Internal.QueryServices;

/// <summary>
///     Query service for managing Technician entities.
/// </summary>
/// <param name="technicianRepository">
///     The technician repository.
/// </param>
public class TechnicianQueryService(ITechnicianRepository technicianRepository)
: ITechnicianQueryService
{
    /// <summary>
    ///     Handles the retrieval of all technicians.
    /// </summary>
    /// <param name="query">
    ///     The query to get all technicians.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of all Technician entities.
    /// </returns>
    public async Task<IEnumerable<Technician>> Handle(GetAllTechniciansQuery query)
    {
        return await technicianRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the retrieval of a technician by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query to get a technician by its ID.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the Technician entity if found; otherwise, throws NotFoundIdException.
    /// </returns>
    /// <exception cref="NotFoundIdException"></exception>
    public async Task<Technician?> Handle(GetTechnicianByIdQuery query)
    {
        return await technicianRepository.FindByIdAsync(query.IdTechnician)
            ?? throw new NotFoundIdException("Technician with the id " + query.IdTechnician + " was not found.");
    }
}