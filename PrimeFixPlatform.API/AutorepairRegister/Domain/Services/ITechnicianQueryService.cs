using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Queries;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Services;

/// <summary>
///     Represents a repository interface for handling technician queries.
/// </summary>
public interface ITechnicianQueryService
{
    /// <summary>
    ///     Handles the GetAllTechniciansQuery to retrieve all technicians.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving technicians.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable of technicians.
    /// </returns>
    Task<IEnumerable<Technician>> Handle(GetAllTechniciansQuery query);
    
    /// <summary>
    ///     Handles the GetTechnicianByIdQuery to retrieve a technician by its ID.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the ID of the technician to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the technician if found; otherwise, null.
    /// </returns>
    Task<Technician?> Handle(GetTechnicianByIdQuery query);
}